using System;
using System.Linq;
using Domain.Infrastructure;
using Domain.Infrastructure.Log;
using Domain.Infrastructure.Repositories;
using Domain.Infrastructure.Services;
using Domain.Models;

namespace Services.Concrete
{
    public class ApiUserService : IApiUserService
    {
        private readonly IRepository<ApiUser> _apiUserRepository;
        private readonly IHashProvider _hashProvider;

        public ApiUserService(IUnitOfWork unitOfWork, IHashProvider hashProvider)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }

            if (hashProvider == null)
            {
                throw new ArgumentNullException("hashProvider");
            }

            _apiUserRepository = unitOfWork.Get<ApiUser>();
            _hashProvider = hashProvider;
        }

        public ApiUser GetUserWithKey(string apiKey)
        {
            ApiUser result = _apiUserRepository.Get(user => user.ApiKey == apiKey).FirstOrDefault();

            return result;
        }

        public string GetSignatureForUser(ApiUser user)
        {
            string signature = _hashProvider.GetHash(user.ApiKey, user.Secret);

            return signature;
        }
    }
}