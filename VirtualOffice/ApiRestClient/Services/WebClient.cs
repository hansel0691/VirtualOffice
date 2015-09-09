using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ApiRestClient.Infrastructure;
using ApiRestClient.Models;
using Domain.Models.Exceptions;
using RestSharp;
using Domain.Infrastructure.Services;
using System.Reflection;
using Newtonsoft.Json;

namespace ApiRestClient.Services
{
    public class WebClient : IWebClient
    {
        private readonly IAuthService _authService;
        private readonly IHashProvider _hashProvider;
        private ApiToken _token ;
        //private readonly ILogger _logger;

        public WebClient(IAuthService authService, IHashProvider hashProvider, /*ILogger logger,*/ bool saveToken = true)
        {
            UseSavedToken = saveToken;

            //_logger = logger;
            _authService = authService;
            _hashProvider = hashProvider;

            UseSavedToken = true;
            _token = new ApiToken();
        }

        public bool UseSavedToken { get; private set; }

        public T Execute<T>(IEnumerable<KeyValuePair<string, object>> requestParams, string key, string secret, RequestInfo requestInfo) where T : new()
        {
            if (requestParams == null)
            {
                //_logger.Info(String.Format("Request params are null"));

                throw new ArgumentNullException("requestParams");
            }

            if (UseSavedToken)
            {
                if (TokenNeeded())
                {
                    /*_logger.Info(String.Format("New Token is needed"));
                    _logger.Info(String.Format("Starting operation: GetToken"));*/
                    _token = GetToken(key, secret, requestInfo.AuthUrl);
                    //_logger.Info(String.Format("Generated token is {0}", _token.Token));
                }
            }
            else
            {
                /*_logger.Info(String.Format("Getting saved token"));
                _logger.Info(String.Format("Starting operation: GetToken"));*/
                _token = GetToken(key, secret, requestInfo.AuthUrl);
                //_logger.Info(String.Format("Saved token is {0}", _token.Token));
            }

            if (!IsValidToken(_token))
            {
                /*_logger.Info(String.Format("Not valid token"));
                _logger.Info(String.Format("Starting operation: GetToken"));*/

                _token = GetToken(key, secret, requestInfo.AuthUrl);

                //_logger.Info(String.Format("Generated token is {0}", _token.Token));
            }

            //_logger.Info(String.Format("Request web service url: {0}", requestInfo.RequestUrl));

            var result = ExecuteRequest<T>(key, _token.Token, requestInfo.RequestUrl, requestInfo.Method, requestParams);

            return result;
        }

        public T Execute<T>(object requestParamsObj, string key, string secret, RequestInfo requestInfo) where T : new()
        {
            if (requestParamsObj == null)
            {
                //_logger.Info(String.Format("Request params objects are null"));

                throw new ArgumentNullException("requestParamsObj");
            }

            IEnumerable<KeyValuePair<string, object>> requestParams = GetParamsFromObject(requestParamsObj);

            return Execute<T>(requestParams, key, secret, requestInfo);
        }

        public TResult Execute<TResult>(string json, string key, string secret, RequestInfo requestInfo) where TResult : new()
        {
            return Execute<TResult>(new { Data = json }, key, secret, requestInfo);
        }

        public TResult Execute<TResult>(string key, string secret, RequestInfo requestInfo) where TResult : new()
        {
            return Execute<TResult>(new object(), key, secret, requestInfo);
        }

        private T ExecuteRequest<T>(string key, string token, string url, Method method, IEnumerable<KeyValuePair<string, object>> requestParams) where T : new()
        {
            var restClient = new RestClient(url)
            {
                Authenticator = new HttpBasicAuthenticator(key, token)
            };

            var request = new RestRequest(method)
            {
                RequestFormat = DataFormat.Json,
                Timeout = 1000000 * 10
            };

            foreach (var param in requestParams)
            {
                request.AddParameter(param.Key, param.Value);
            }

            IRestResponse<T> response = restClient.Execute<T>(request);

       
             switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound: throw new NotFoundException();

                case HttpStatusCode.InternalServerError: throw new InternalServerErrorException();
            }
          
            T responseData = response.Data;

            return responseData;
        }

        private string GetContent(string str)
        {
            StringBuilder result = new StringBuilder();

            int c = 0;

            foreach (var item in str)
            {
                result.Append(item);

                if (item == '[')
                {
                    c++;
                }
                else if (item == ']')
                {
                    c--;
                }

                if (c == 0)
                    return result.ToString();
            }

            return string.Empty;
        }

        private bool IsValidToken(ApiToken token)
        {
            return token!=null && token.ExpirationDate < DateTime.Now;
        }

        private ApiToken GetToken(string key, string secret, string url)
        {
            string signature = _hashProvider.GetHash(key, secret);

            ApiToken token = _authService.RequestToken(key, signature, url);

            return token;
        }

        private bool TokenNeeded()
        {
            return _token == null;
        }

        private IEnumerable<KeyValuePair<string, object>> GetParamsFromObject(object requestParamsObj)
        {
            foreach (PropertyInfo property in requestParamsObj.GetType().GetProperties())
            {
                string name = property.Name;
                object value = property.GetValue(requestParamsObj, null);

                yield return new KeyValuePair<string, object>(name, value);
            }
        }

        private string ToJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);

            return json;
        }

        private T FromJson<T>(string jsonData)
        {
            T result = JsonConvert.DeserializeObject<T>(jsonData);

            return result;
        }
    }
}
