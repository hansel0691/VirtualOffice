using System;
using System.Net;
using System.Web.Http;
using RestSharp;
using ApiRestClient.Infrastructure;
using ApiRestClient.Models;

namespace ApiRestClient.Services
{
    public class AuthService : IAuthService
    {
        public ApiToken RequestToken(string apiKey, string signature, string url)
        {
            try
            {
                var restClient = new RestClient(url);

                var request = new RestRequest(Method.POST);

                request.AddParameter("apiKey", apiKey);
                request.AddParameter("signature", signature);

                IRestResponse<ApiToken> response = restClient.Execute<ApiToken>(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new HttpResponseException(response.StatusCode);
                }

                ApiToken token = response.Data;

                return token;
            }
            catch (Exception)
            {

                return null;
            }
          
        }

        public bool ValidateTokenTime(ApiToken token)
        {
            return token.ExpirationDate > DateTime.Now;
        }
    }
}
