using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Infrastructure.Services
{
    public interface IUserService
    {
        User GetUser(string userName, string password);
        
        User ChangeUserPassword(User user, string newPassword);
        
        int GetEmployeeId(User user);
        
        void AddHashToUser(User user, string hash);

        void AddTokenForBlackstoneMerchantUser(string userId, string password, string token);

        User GetUserWithKey(string key);
    }
}
