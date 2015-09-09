using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using CoreData.Models;
using CoreData.Models.Mapping;
using Domain.Infrastructure.Log;
using Domain.Models;
using Domain.Models.Orders;


namespace CoreData.Contexts
{
    public class VirtualOfficeContext : DbContext
    {
        private readonly ILogger _logger;

        static VirtualOfficeContext()
        {
            Database.SetInitializer<VirtualOfficeContext>(null);
        }

        public VirtualOfficeContext()
            : base("name=virtual_office")
        {
            
        }

        public VirtualOfficeContext(ILogger logger)
            : base("name=virtual_office")
        {
            _logger = logger;

            var logDbOutput = LoadDbOutputConfiguration();

            if (logDbOutput)
            {
                Database.Log = s => _logger.Debug(s);
            }
        }

        private static bool LoadDbOutputConfiguration()
        {
            string logDdOutputSetting = ConfigurationManager.AppSettings["LOG_DB_OUTPUT"];

            bool logDbOutput = false;
            bool.TryParse(logDdOutputSetting, out logDbOutput);
            return logDbOutput;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PredefinedFilterMapping());
            modelBuilder.Configurations.Add(new ReportMapping());
            modelBuilder.Configurations.Add(new ReportPredefinedFilterRelMapping());
            modelBuilder.Configurations.Add(new ReportToReportRelMappign());
          
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new UserReportMapping());
            modelBuilder.Configurations.Add(new TokenMapping());
            modelBuilder.Configurations.Add(new ApiUserMapping());
            modelBuilder.Configurations.Add(new UserTypeMapping());

            modelBuilder.Configurations.Add(new UserReportFilterMapping());
            modelBuilder.Configurations.Add(new UserReportFilterValueMapping());

            modelBuilder.Configurations.Add(new ReportLabelMapping());
        }

        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<AuthToken> Tokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ApiUser> ApiUsers { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        //public DbSet<UserFilter> UserFilters { get; set; }
        public DbSet<PredefinedFilter> PredefinedFilters { get; set; }
        public DbSet<ReportPredefinedFilterRel> ReportPredefinedFilters { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<HashKey> HashKeys { get; set; }

        public IEnumerable<Parameter> GetParameterFromStoredProcedure(string storeProcedureName)
        {
            SqlParameter _storeProcedureName = new SqlParameter("@procedure_name", storeProcedureName);
            var result = Database.SqlQuery<Parameter>("sp_retrieve_parameters @procedure_name", _storeProcedureName);
            return result;
        }

        public RawUser LogInUser(string userName, string password)
        {
            SqlParameter _userId = new SqlParameter("@userid", userName);
            SqlParameter _passCredential = new SqlParameter("@passCredential", password);

            var result = Database.SqlQuery<RawUser>("get_user @userid, @passCredential",
                _userId, 
                _passCredential)
                .FirstOrDefault();

            return result;
        }

        public void ChangeUserPassword(int userName, string newPassword)
        {
            SqlParameter _user_Id = new SqlParameter("@user_id", userName);
            SqlParameter _password = new SqlParameter("@password", newPassword);

            Database.ExecuteSqlCommand("sp_update_user_password @user_id, @password",
                _user_Id,
                _password);
        }

        public IEnumerable<RawInventoryItem> GetInventoryItems()
        {
            var items = Database.SqlQuery<RawInventoryItem>("sp_get_marketing_materials").ToArray();

            return items;
        }
    }
}
