using System.Data.Entity.ModelConfiguration;
using CoreData.Contexts;
using Domain.Models;

namespace CoreData.Models.Mapping
{
    public class IncidentMapping : EntityTypeConfiguration<Incident>
    {
        public IncidentMapping()
        {
            this.Ignore(lead => lead.RowVersion);
            this.Ignore(lead => lead.TimeSpan);

            this.Property(incident => incident.Id)
                .HasColumnName("ID");

            this.Property(incident => incident.AgentId)
                .HasColumnName("agent_id");

            this.Property(incident => incident.CustomerId)
                .HasColumnName("customer_id");

            this.Property(incident => incident.MerchantName)
                .HasColumnName("Merchant");

            this.Property(incident => incident.Type)
                .HasColumnName("Incident Type");

            this.Property(incident => incident.Statuts)
                .HasColumnName("Incident Status");

            this.Property(incident => incident.TerminalId)
                .HasColumnName("Terminal Id");

            this.Property(incident => incident.DateOpened)
                .HasColumnName("Date Opened");

            this.Property(incident => incident.DateClosed)
                .HasColumnName("Date Closed");

            this.ToTable("incidents_view");
        }
    }

    public class LeadMapping : EntityTypeConfiguration<Lead>
    {
        public LeadMapping()
        {
            this.Ignore(lead => lead.RowVersion);
            this.Ignore(lead => lead.TimeSpan);
          
            this.Property(lead => lead.Id)
                .HasColumnName("Lead#");

            this.Property(lead => lead.CreatedBy)
                .HasColumnName("createdBy");

            this.Property(lead => lead.LeadSource)
                .HasColumnName("leadSource");

            this.Property(lead => lead.UserAdder_empId)
                .HasColumnName("Emp#");

            this.Property(lead => lead.AssignedTo)
                .HasColumnName("Assigned to");

            this.Property(lead => lead.Company)
                .HasColumnName("Company");

            this.Property(lead => lead.ContactPerson)
                .HasColumnName("Contact person");

            this.Property(lead => lead.BusinessAddress)
                .HasColumnName("Business address");

            this.Property(lead => lead.City)
                .HasColumnName("City");

            this.Property(lead => lead.State)
                .HasColumnName("State");

            this.Property(lead => lead.Zip)
                .HasColumnName("Zip");

            this.Property(lead => lead.Phone)
                .HasColumnName("Phone");

            this.Property(lead => lead.State)
                .HasColumnName("State");

            this.Property(lead => lead.BusinessType)
                .HasColumnName("Business type");

            this.Property(lead => lead.AreaOfInterest)
                .HasColumnName("Area of Interest");

            this.Property(lead => lead.Entered)
                .HasColumnName("Entered");

            this.Property(lead => lead.Contacted)
                .HasColumnName("Contacted");

            this.Property(lead => lead.NextVisit)
                .HasColumnName("Nxt.Visit");

            this.Property(lead => lead.ClosedOn)
                .HasColumnName("Closed on");

            this.Property(lead => lead.Status)
                .HasColumnName("Status");

            this.Property(lead => lead.Comments)
                .HasColumnName("Comments");

            this.Property(lead => lead.AgentId)
                .HasColumnName("agentID");

            this.ToTable("view_opened_leads");
        }
    }

    public class ExternalLoginMapping : EntityTypeConfiguration<VonageExternalLogin>
    {
    }
}