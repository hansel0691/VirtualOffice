using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;
using Domain.Infrastructure.Repositories;
using Domain.Models;

namespace Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<T> Get<T>() where T : BaseUModel;

        TRepository GetRepository<TRepository>();

        void Commit();
    }
}
