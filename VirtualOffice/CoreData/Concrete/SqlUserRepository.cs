using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.Internal;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Exceptions;
using Domain.Models.Handlers;

namespace CoreData.Concrete
{
    public class SqlUserRepository : Repository<User>, IUserRepository
    {
        private readonly VirtualOfficeContext context;

        public SqlUserRepository(VirtualOfficeContext context)
            :base(context.Set<User>())
        {
            this.context = context;
        }

        public User LogIn(string userName, string password)
        {
            try
            {
                var user = context.LogInUser(userName, password);

                if (user == null)
                {
                    return null;
                }

                return new User
                {
                    RefId = user.userid,
                    Category = (Category) user.usertype,
                    Id = 0,
                    Address1 = user.address1,
                    Address2 = user.address2,
                    BusinessName = user.businessName,
                    Comission = user.comission,
                    Email = user.email,
                    Phone = user.phone,
                    State = user.state,
                    ZipCode = user.zipCode,
                    Name = user.username,
                    City = user.city, 
                    Tokens = new List<HashKey>()
                };
            }
            catch (Exception e)
            {
                throw new DataAccessException("Impossible to log in user", e);
            }
        }

        public User ChangePassword(User user, string newPassword)
        {
            try
            {
                context.ChangeUserPassword(user.RefId, newPassword);

                User userResult = LogIn(user.RefId.ToString(), newPassword);

                return userResult;
            }
            catch (Exception e)
            {
                throw new DataAccessException("Impossible to change user password", e);
            }
        }

        public override void Add(User entity)
        {
            var dbUser = Get(p => p.RefId == entity.RefId && p.Category == entity.Category).FirstOrDefault();

            if (dbUser == null)
            {
                base.Add(entity);
                InvokeOnAdd(new UserAddedEventHandlerArgs(entity));
                context.SaveChanges();
            }
        }

        public override User GetByID(params object[] ids)
        {
            int id = (int) ids[0];

            return Get(p => p.RefId ==  id).FirstOrDefault();
        }
    }
}
