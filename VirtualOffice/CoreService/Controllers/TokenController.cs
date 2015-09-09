using System.Net;
using System.Net.Http;
using System.Web.Http;
using CoreService.Models;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;
using RestSharp;

namespace CoreService.Controllers
{
    public class TokenController : ApiController
    {
        private readonly IApiUserService _apiUserService;
        private readonly ITokenService _tokenService;
        private readonly ILogger _logger;

        public TokenController(IApiUserService apiUserService, ITokenService tokenService, ILogger logger)
        {
            _apiUserService = apiUserService;
            _tokenService = tokenService;
            _logger = logger;
        }

        [HttpPost]
        public IHttpActionResult PostToken([FromBody] TokenRequestModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Empty Request");
            }

            ApiUser user = _apiUserService.GetUserWithKey(model.ApiKey);

            if (user == null)
            {
                return this.NotFound();
            }

            string userSignature = _apiUserService.GetSignatureForUser(user);

            if (userSignature == model.Signature)
            {
                AuthToken token = _tokenService.GetNewTokenForUser(user);

                var response = new TokenModel(token);

                return this.Ok(response);
            }

            return this.ResponseMessage(Request.CreateResponse(HttpStatusCode.Unauthorized, new TokenModel {ErrorObject = new {model.Signature}}));
        }


        [HttpGet]
        public IHttpActionResult TestPostToken()
        {
            _logger.Debug("Logging something");

            string apiKey = "abc";
            ApiUser user = _apiUserService.GetUserWithKey(apiKey);

            string signature = _apiUserService.GetSignatureForUser(user);

            //var token = NewsStyleUriParser 
                //PostToken(new TokenRequestModel {ApiKey = apiKey, Signature = signature});


            return PostToken(new TokenRequestModel
            {
                ApiKey = apiKey,
                Signature = signature
            });


            string a = "";

            RestClient client = new RestClient("http://virtualofficeservice.pinserve.com/api/Token/PostToken")
            {
                Authenticator = new HttpBasicAuthenticator("abc", a)
            };

            RestRequest request = new RestRequest(Method.POST);

            request.AddParameter("ApiKey", apiKey);
            request.AddParameter("Signature", signature);

            var token = client.Execute<TokenModel>(request);


            return Ok(token.Data);
        }
    }
}
