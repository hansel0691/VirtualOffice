using System;
using System.Diagnostics;
using CoreData.Contexts;
using Domain.Infrastructure;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Ninject;

namespace CoreData.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IKernel _kernel;
        private readonly VirtualOfficeContext _context;

        public UnitOfWork(IKernel kernel, VirtualOfficeContext context)
        {
            _kernel = kernel;
            _context = context;
        }

        public IRepository<T> Get<T>() where T : BaseUModel
        {
            var respositoy = new Repository<T>(_context.Set<T>());

            return respositoy;
        }

        public TRepository GetRepository<TRepository>()
        {
            var repository = (TRepository)_kernel.TryGet(typeof(TRepository));

            return repository;
        }

        public void Commit()
        {
            if (_context != null)
            {
               int changes = _context.SaveChanges();

                Trace.WriteLine(string.Format("Number of changes on db: {0}", changes));
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
