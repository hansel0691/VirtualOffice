using System;

namespace Domain.Models.Handlers
{
    public class EntityAddedEventHandlerArgs<TEntity> : EventArgs
    {
        public TEntity Entity { get; set; }
    }
}