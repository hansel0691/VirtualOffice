using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Controllers;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace CoreService.Filters
{
    public class AuthorizationFilter : AuthorizeAttribute
    {
        private ITokenService _tokenService { get; set; }
        private ILogger _logger { get; set; }

        public AuthorizationFilter()
        {
            _tokenService = GetTokenService();
            _logger = GetLogger();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            AuthenticationHeaderValue authHeader = actionContext.Request.Headers.Authorization;

            if (authHeader == null || authHeader.Parameter == null)
            {
                HandleUnauthorizeRequest(actionContext);
                return;
            }

            string rawCredentials = authHeader.Parameter;
            Encoding enconding = Encoding.UTF8;

            string credentials = enconding.GetString(Convert.FromBase64String(rawCredentials));

            string[] values = credentials.Split(':');

            if (values.Length < 2)
            {
                HandleUnauthorizeRequest(actionContext);
                return;
            }

            string apiKey = values[0];
            string token = values[1];

            _logger.Info(string.Format("Key: {0}", apiKey));
            _logger.Info(string.Format("Token: {0}", token));

            AuthToken authToken = _tokenService.GetToken(token);

            if (authToken == null)
            {
                _logger.Debug("Token not found");
                HandleUnauthorizeRequest(actionContext);
                return;
            }

            _logger.Debug("Token found");

            if (authToken.IsActive)
            {
                _logger.Debug("Token active");

                if (authToken.ApiUser.ApiKey == apiKey && authToken.Expiration > DateTime.Now)
                {
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(authToken.ApiUser.ApiKey), null);
                    Thread.CurrentPrincipal = principal;
                }
            }
            else
            {
                _logger.Debug("Token not active");
                HandleUnauthorizeRequest(actionContext);
            }
        }
        
        private void HandleUnauthorizeRequest(HttpActionContext actionContext)
        {
            _logger.Debug("Unauthorized");
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private ITokenService GetTokenService()
        {
            return (ITokenService)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ITokenService));
        }

        private ILogger GetLogger()
        {
            return (ILogger)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ILogger));
        }
    }
}