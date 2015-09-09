using System;
using Domain.Models;

namespace CoreService.Models
{
    public class TokenModel : BaseResponse
    {
        public TokenModel()
        {
        }

        public TokenModel(AuthToken token)
        {
            Token = token.Value;
            ExpirationDate = token.Expiration;
        }

        public DateTime ExpirationDate { get; set; }

        public string Token { get; set; }
    }
}