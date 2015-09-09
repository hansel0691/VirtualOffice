using System;
using System.Data.Entity;
using CoreData.Models.Mapping;
using Domain.Models;

namespace CoreData.Contexts
{
    public class PindataContext : DbContext
    {
        public PindataContext()
            : base("name=pin_data")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LeadMapping());
            modelBuilder.Configurations.Add(new IncidentMapping());
        }

        public DbSet<Lead> OpenLeads { get; set; }

        public DbSet<Incident> Incidents { get; set; }
    }
}