using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface ITokenService
    {
        AuthToken GetNewTokenForUser(ApiUser user);

        AuthToken GetToken(string token);

        AuthToken GetActiveTokenForUser(ApiUser user);
    }
}
