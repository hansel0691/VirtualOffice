using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestClient.Models;

namespace ApiRestClient.Infrastructure
{
    public interface IAuthService
    {
        ApiToken RequestToken(string apiKey, string signature, string url);

        bool ValidateTokenTime(ApiToken token);
    }
}
