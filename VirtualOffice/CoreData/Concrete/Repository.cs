using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Handlers;

namespace CoreData.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseUModel
    {
        //private readonly DbContext context;
        private DbSet<TEntity> dbSet;

        private TEntity x;

        //public Repository(VirtualOfficeContext context)
        //{
        //    this.context = context;
        //    this.dbSet = context.Set<TEntity>();
        //}

        public Repository(DbSet<TEntity> dbSet)
        {
            if (dbSet == null)
            {
                throw new ArgumentNullException("dbSet");
            }

            this.dbSet = dbSet;
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(params object[] ids)
        {
            var result = dbSet.Find(ids);

            return result;
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);

        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);

            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            //if (context.Entry(entityToDelete).State == EntityState.Deleted)
            //{
            //    dbSet.Attach(entityToDelete);
            //}

            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            //if (context.Entry(entityToUpdate).State == EntityState.Detached)
            //{
            //    dbSet.Attach(entityToUpdate);
            //}

            dbSet.AddOrUpdate(entityToUpdate);
        }

        public virtual void Commit()
        {
            //context.SaveChanges();
        }

        public event EntityAddedEventHandler<TEntity> OnAdd;

        public event EventHandler OnDelete;

        protected virtual void InvokeOnAdd(EntityAddedEventHandlerArgs<TEntity> args)
        {
            EntityAddedEventHandler<TEntity> handler = OnAdd;
            
            if (handler != null)
            {
                handler(this, args);
            }
        }

        protected virtual void InvokeOnDelete(EventArgs args)
        {
            EventHandler handler = OnDelete;

            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}