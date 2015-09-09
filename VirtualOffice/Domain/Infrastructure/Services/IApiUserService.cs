using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IApiUserService
    {
        ApiUser GetUserWithKey(string apiKey);

        string GetSignatureForUser(ApiUser user);
    }
}
