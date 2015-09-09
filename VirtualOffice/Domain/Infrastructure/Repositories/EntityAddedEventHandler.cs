using Domain.Models;
using Domain.Models.Handlers;

namespace Domain.Infrastructure.Repositories
{
    public delegate void EntityAddedEventHandler<TEntity>(object sender, EntityAddedEventHandlerArgs<TEntity> args);
}