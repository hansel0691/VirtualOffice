using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreData.BlackstoneDb.Models;
using CoreData.BlackstoneDb.Models.Mapping;
using Domain.Blackstone;

namespace CoreData.BlackstoneDb.Context
{
    public class BlackstoneDbContext : DbContext
    {
        public BlackstoneDbContext()
            :base("name=BlackstoneContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeMap());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
