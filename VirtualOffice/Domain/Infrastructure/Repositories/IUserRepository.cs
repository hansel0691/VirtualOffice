using Domain.Models;

namespace Domain.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User LogIn(string userName, string password);

        User ChangePassword(User user, string newPassword);
    }
}