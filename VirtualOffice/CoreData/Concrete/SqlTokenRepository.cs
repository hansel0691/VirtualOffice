using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Handlers;

namespace CoreData.Concrete
{
    public class SqlTokenRepository : Repository<AuthToken>, ITokenRepository
    {
        public SqlTokenRepository(VirtualOfficeContext context) 
            : base(context.Set<AuthToken>())
        {
        }

        public override void Add(AuthToken token)
        {
            base.Add(token);

            InvokeOnAdd(new EntityAddedEventHandlerArgs<AuthToken>());

            DeleteInvalidTokenForUserAsync(token)
                .ContinueWith(task =>
                    {
                        InvokeOnDelete(new EventArgs());
                    });
        }

        private Task DeleteInvalidTokenForUserAsync(AuthToken token)
        {
            return new TaskFactory().StartNew(() =>
                {
                    IEnumerable<AuthToken> invalidTokens = GetInvalidTokensForUser(token.ApiUserId).ToArray();

                    foreach (var invalidToken in invalidTokens)
                    {
                        Delete(invalidToken);
                    }
                });
        }

        private IEnumerable<AuthToken> GetInvalidTokensForUser(int apiUserId)
        {
            return Get(t => t.ApiUser.Id == apiUserId && t.Expiration < DateTime.Now);
        }
    }
}
