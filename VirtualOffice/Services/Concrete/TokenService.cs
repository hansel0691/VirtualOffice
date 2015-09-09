using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace Services.Concrete
{
    public class TokenService : ITokenService
    {
        private const int DEFAULT_TOKEN_TIME_IN_MINUTES = 5;
        private readonly IHashProvider _hashProvider;
        private readonly ITokenRepository _tokenRespository;

        private Random randomGen = new Random((int)DateTime.Now.Ticks);

        public TokenService(IHashProvider hashProvider, IUnitOfWork unitOfWork)
        {
            _hashProvider = hashProvider;
            _tokenRespository = unitOfWork.GetRepository<ITokenRepository>();

            _tokenRespository.OnAdd += (sender, args) => unitOfWork.Commit();
            _tokenRespository.OnDelete += (sender, args) => unitOfWork.Commit();
        }

        public AuthToken GetNewTokenForUser(ApiUser user)
        {
            string key = user.Secret;
            string data = user.UserName + user.Password + user.GetHashCode() + randomGen.Next();

            string hash = _hashProvider.GetHash(key, data);

            var resultToken = new AuthToken
            {
                Value = hash,
                ApiUser = user,
                Expiration = DateTime.Now.AddMinutes(DEFAULT_TOKEN_TIME_IN_MINUTES),
                IsActive = true
            };

            _tokenRespository.Add(resultToken);

            return resultToken;
        }

        public AuthToken GetToken(string token)
        {
            AuthToken tokenResult = _tokenRespository.Get(t => t.Value == token).FirstOrDefault();

            return tokenResult;
        }

        public AuthToken GetActiveTokenForUser(ApiUser user)
        {
            AuthToken activeToken = _tokenRespository.Get(token => token.IsActive).FirstOrDefault();

            return activeToken;
        }
    }
}
