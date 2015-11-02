using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;
using VirtualOffice.Data.Helpers;

namespace VirtualOffice.Data.Repositories
{
    public class UserRepository: BaseRepository
    {
        public get_user_Result GetUser(int agentId)
        {
            //Making the SP to ignore the password...

            var getUserResult = VirtualOfficeContext.get_user(agentId.ToString(), "EAA6DD0D-CE53-445E-976E-363814FCC77F");

            var result = getUserResult.FirstOrDefault();

            return result;
        }

        public get_user_Result GetUser(string agentId, string password)
        {
            var getUserResult = VirtualOfficeContext.get_user(agentId, password);

            var result = getUserResult.FirstOrDefault();

            if(result!= null) // Adding the agent if it's the first time login into the Virtual Office
                AddUserIfNeccesary(result);

            return result;
        }

        private IEnumerable<get_agents_Result> GetAgents()
        {
            var allAgents = VirtualOfficeContext.get_agents();

            return allAgents;
        }

        public IEnumerable<get_user_Result> GetAllAgentUsers()
        {
            var allAgents = GetAgents();

            return allAgents.Select(agent => GetUser(agent.AgentId));
        }

        public User GetUserByAgentId(int agentId)
        {
            var user = VirtualOfficeContext.Users.FirstOrDefault(u => u.RefId == agentId);

            return user;
        }

        public void AddUserIfNeccesary(get_user_Result agent)
        {
            var user = VirtualOfficeContext.Users.FirstOrDefault(u => u.RefId == agent.userid);

            if (user == null)
            {
                var newUser = new User
                {
                    RefId = agent.userid,
                    Category = agent.usertype,
                    RowVersion = Helper.GetVersionRow(),
                    TimeSpan = DateTime.Now
                };
                
                VirtualOfficeContext.Users.Add(newUser);
                VirtualOfficeContext.SaveChanges();
            }

            
        }

        public string GetUserRole(int userId)
        {
            var user = VirtualOfficeContext.user_roles.FirstOrDefault(u => u.AgentId == userId);

            return user != null ? user.Role : string.Empty;

        }

        public bool UpdatePersonalInfo(int id, string email, string phone, bool isMerchant)
        {
            var editedUsers = VirtualOfficeContext.sp_update_information(id, isMerchant ? 1 : 0, email, phone);
            
            return editedUsers == 1;
        }

    }
}
