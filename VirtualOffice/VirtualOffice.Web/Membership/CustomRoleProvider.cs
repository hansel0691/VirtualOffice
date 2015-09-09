using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Antlr.Runtime;
using VirtualOffice.Service.Services;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;

namespace VirtualOffice.Web.Membership
{
    public class CustomRoleProvider: RoleProvider
    {

        public override bool IsUserInRole(string username, string roleName)
        {
            var userLoggedToSession = HttpContext.Current.Session[Utils.LoggedUserKey];

            if (userLoggedToSession.IsNull())
                return false;

            var user = userLoggedToSession as UserModel;

            return  user!= null && user.Role.Equals(roleName);
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var userLoggedToSession = HttpContext.Current.Session[Utils.LoggedUserKey];

                if (userLoggedToSession.IsNull())
                    return new string[] {};

                var user = userLoggedToSession as UserModel;

                if (user == null)
                    return new string[] {};

                var rolesResult = new List<string>{Utils.UserKey}; //everybody that could log in is a USER

                if(!string.IsNullOrEmpty(user.Role)) //If the Role (potentially another one may be determined then it's added to the list of roles)
                    rolesResult.Add(user.Role);

                return rolesResult.ToArray();
            }
            catch (Exception exception)
            {
                return new string[] { };
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}