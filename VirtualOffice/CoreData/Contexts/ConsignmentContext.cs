using System.Data.Entity;
using System.Data.SqlClient;
using CoreData.Models.Mapping;
using Domain.Models;

namespace CoreData.Contexts
{
    public class ConsignmentContext : DbContext
    {
        public ConsignmentContext()
            : base("name=consignment")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConsignmentTypeMapping());
        }

        public DbSet<ConsignmentType> Types { get; set; }

        public int Add(NewLead lead)
        {
            SqlParameter Company = new SqlParameter("@Company", lead.Company);
            SqlParameter Contact = new SqlParameter("@Contact", lead.Contact);
            SqlParameter Email = new SqlParameter("@Email", lead.Email);
            SqlParameter Address = new SqlParameter("@Address", lead.Address);
            SqlParameter City = new SqlParameter("@City", lead.City);
            SqlParameter State = new SqlParameter("@State", lead.State);
            SqlParameter Zip = new SqlParameter("@Zip", lead.Zip);
            SqlParameter Phone = new SqlParameter("@Phone", lead.Phone);
            SqlParameter CellPhone = new SqlParameter("@CellPhone", lead.CellPhone);
            SqlParameter Fax = new SqlParameter("@Fax", lead.Fax);
            SqlParameter Industry_Id = new SqlParameter("@Industry_Id", lead.Industry_Id);
            SqlParameter Notes = new SqlParameter("@Notes", lead.Notes);
            SqlParameter Source = new SqlParameter("@Source", lead.Source);
            SqlParameter UserAdder = new SqlParameter("@UserAdder", lead.UserAdder);
            SqlParameter UserAdder_empId = new SqlParameter("@UserAdder_empId", lead.UserAdder_empId);
            SqlParameter nextVisit = new SqlParameter("@nextVisit", lead.nextVisit);
            SqlParameter typeLead = new SqlParameter("@typeLead", lead.typeLead);
            SqlParameter interested = new SqlParameter("@interested", lead.interested);
            SqlParameter hear = new SqlParameter("@hear", lead.hear);
            SqlParameter mailerID = new SqlParameter("@mailerID", lead.mailerID);
            SqlParameter MID = new SqlParameter("@MID", lead.MID);

            int id = 0;
            SqlParameter ID = new SqlParameter("@ID", id);

            SqlParameter CrossMid = new SqlParameter("@CrossMid", lead.CrossMid);
            SqlParameter other = new SqlParameter("@other", lead.other);
            SqlParameter language = new SqlParameter("@language", lead.language);
            SqlParameter ext_company_id = new SqlParameter("@ext_company_id", lead.ext_company_id);
            SqlParameter ext_user_id = new SqlParameter("@ext_user_id", lead.ext_user_id);
            SqlParameter estatus_id = new SqlParameter("@status_id", lead.status_id);

            Database.ExecuteSqlCommand("sp_addLeads "
                                       + "@Company,"
                                       + "@Contact,"
                                       + "@Email,"
                                       + "@Address,"
                                       + "@City,"
                                       + "@State,"
                                       + "@Zip,"
                                       + "@Phone,"
                                       + "@CellPhone,"
                                       + "@Fax,"
                                       + "@Industry_Id,"
                                       + "@Notes,"
                                       + "@Source,"
                                       + "@UserAdder,"
                                       + "@UserAdder_empId,"
                                       + "@nextVisit,"
                                       + "@typeLead,"
                                       + "@interested,"
                                       + "@hear,"
                                       + "@mailerID,"
                                       + "@MID,"
                                       + "@ID,"
                                       + "@CrossMid,"
                                       + "@other,"
                                       + "@language,"
                                       + "@ext_company_id,"
                                       + "@ext_user_id,"
                                       + "@status_id",
                Company,
                Contact,
                Email,
                Address,
                City,
                State,
                Zip,
                Phone,
                CellPhone,
                Fax, 
                Industry_Id,
                Notes,
                Source,
                UserAdder,
                UserAdder_empId,
                nextVisit,
                typeLead,
                interested,
                hear,
                mailerID,
                MID,
                ID,
                CrossMid,
                other,
                language,
                ext_company_id,
                ext_user_id,
                estatus_id
                );

            return id;
        }
    }
}