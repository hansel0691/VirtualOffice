using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface ITokenRepository : IRepository<AuthToken>
    {
        new void Add(AuthToken token);
    }
}