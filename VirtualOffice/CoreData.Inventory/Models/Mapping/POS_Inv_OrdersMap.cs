using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CoreData.Inventory.Models.Mapping
{
    public class POS_Inv_OrdersMap : EntityTypeConfiguration<POS_Inv_Orders>
    {
        public POS_Inv_OrdersMap()
        {
            // Primary Key
            this.HasKey(t => t.orderID);

            // Properties
            this.Property(t => t.orCode)
                .HasMaxLength(20);

            this.Property(t => t.orShipTo)
                .HasMaxLength(50);

            this.Property(t => t.orShipAddress1)
                .HasMaxLength(50);

            this.Property(t => t.orShipAddress2)
                .HasMaxLength(30);

            this.Property(t => t.orShipCity)
                .HasMaxLength(50);

            this.Property(t => t.orShipState)
                .HasMaxLength(50);

            this.Property(t => t.orShipZipCode)
                .HasMaxLength(15);

            this.Property(t => t.orShipPhone)
                .HasMaxLength(25);

            this.Property(t => t.orShipTrackingNumber)
                .HasMaxLength(20);

            this.Property(t => t.orShipCODTrackingNumber)
                .HasMaxLength(20);

            this.Property(t => t.orRefNotes)
                .HasMaxLength(20);

            this.Property(t => t.orComment)
                .HasMaxLength(500);

            this.Property(t => t.cc_type)
                .HasMaxLength(20);

            this.Property(t => t.approval_code)
                .HasMaxLength(20);

            this.Property(t => t.fraudcode)
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.fraudscore)
                .IsFixedLength()
                .HasMaxLength(3);

            this.Property(t => t.fraudreason1)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.fraudreason2)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.fraudreason3)
                .IsFixedLength()
                .HasMaxLength(4);

            this.Property(t => t.ccaddress1)
                .HasMaxLength(50);

            this.Property(t => t.ccaddress2)
                .HasMaxLength(30);

            this.Property(t => t.ccCity)
                .HasMaxLength(50);

            this.Property(t => t.ccState)
                .HasMaxLength(50);

            this.Property(t => t.ccCountry)
                .HasMaxLength(50);

            this.Property(t => t.ccphone)
                .HasMaxLength(25);

            this.Property(t => t.ccZip)
                .HasMaxLength(15);

            this.Property(t => t.ccFirstName)
                .HasMaxLength(50);

            this.Property(t => t.ccLastName)
                .HasMaxLength(50);

            this.Property(t => t.incident_username)
                .HasMaxLength(50);

            this.Property(t => t.acct_rep)
                .HasMaxLength(100);

            this.Property(t => t.orEditor_Username)
                .HasMaxLength(15);

            this.Property(t => t.acct_rep_phone)
                .HasMaxLength(15);

            this.Property(t => t.raw1)
                .HasMaxLength(100);

            this.Property(t => t.raw1serial)
                .HasMaxLength(100);

            this.Property(t => t.raw2)
                .HasMaxLength(100);

            this.Property(t => t.raw2serial)
                .HasMaxLength(100);

            this.Property(t => t.raw3)
                .HasMaxLength(100);

            this.Property(t => t.raw3serial)
                .HasMaxLength(100);

            this.Property(t => t.orShipEmail)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("POS_Inv_Orders");
            this.Property(t => t.orderID).HasColumnName("orderID");
            this.Property(t => t.orCode).HasColumnName("orCode");
            this.Property(t => t.orQueuedDate).HasColumnName("orQueuedDate");
            this.Property(t => t.orPrepareDate).HasColumnName("orPrepareDate");
            this.Property(t => t.orReadyToShipDate).HasColumnName("orReadyToShipDate");
            this.Property(t => t.orProcessedDate).HasColumnName("orProcessedDate");
            this.Property(t => t.orStatus).HasColumnName("orStatus");
            this.Property(t => t.orPriority).HasColumnName("orPriority");
            this.Property(t => t.merchant_FK).HasColumnName("merchant_FK");
            this.Property(t => t.deploymethID).HasColumnName("deploymethID");
            this.Property(t => t.FedExHomeDelivery).HasColumnName("FedExHomeDelivery");
            this.Property(t => t.FedExSaturdayDelivery).HasColumnName("FedExSaturdayDelivery");
            this.Property(t => t.orShipType).HasColumnName("orShipType");
            this.Property(t => t.orType).HasColumnName("orType");
            this.Property(t => t.Incident).HasColumnName("Incident");
            this.Property(t => t.orPreparedBy).HasColumnName("orPreparedBy");
            this.Property(t => t.orProcessedBy).HasColumnName("orProcessedBy");
            this.Property(t => t.orShippedBy).HasColumnName("orShippedBy");
            this.Property(t => t.orCanceledBy).HasColumnName("orCanceledBy");
            this.Property(t => t.orShipTo).HasColumnName("orShipTo");
            this.Property(t => t.orShipAddress1).HasColumnName("orShipAddress1");
            this.Property(t => t.orShipAddress2).HasColumnName("orShipAddress2");
            this.Property(t => t.orShipCity).HasColumnName("orShipCity");
            this.Property(t => t.orShipState).HasColumnName("orShipState");
            this.Property(t => t.orShipZipCode).HasColumnName("orShipZipCode");
            this.Property(t => t.orShipPhone).HasColumnName("orShipPhone");
            this.Property(t => t.orShipTrackingNumber).HasColumnName("orShipTrackingNumber");
            this.Property(t => t.orShipCODTrackingNumber).HasColumnName("orShipCODTrackingNumber");
            this.Property(t => t.orRefNotes).HasColumnName("orRefNotes");
            this.Property(t => t.orComment).HasColumnName("orComment");
            this.Property(t => t.inv_id_FK).HasColumnName("inv_id_FK");
            this.Property(t => t.order_tax).HasColumnName("order_tax");
            this.Property(t => t.order_discount).HasColumnName("order_discount");
            this.Property(t => t.order_net).HasColumnName("order_net");
            this.Property(t => t.pmt_method).HasColumnName("pmt_method");
            this.Property(t => t.cc_type).HasColumnName("cc_type");
            this.Property(t => t.exp_month).HasColumnName("exp_month");
            this.Property(t => t.exp_year).HasColumnName("exp_year");
            this.Property(t => t.approval_code).HasColumnName("approval_code");
            this.Property(t => t.fraudcode).HasColumnName("fraudcode");
            this.Property(t => t.fraudscore).HasColumnName("fraudscore");
            this.Property(t => t.fraudreason1).HasColumnName("fraudreason1");
            this.Property(t => t.fraudreason2).HasColumnName("fraudreason2");
            this.Property(t => t.fraudreason3).HasColumnName("fraudreason3");
            this.Property(t => t.ccaddress1).HasColumnName("ccaddress1");
            this.Property(t => t.ccaddress2).HasColumnName("ccaddress2");
            this.Property(t => t.ccCity).HasColumnName("ccCity");
            this.Property(t => t.ccState).HasColumnName("ccState");
            this.Property(t => t.ccCountry).HasColumnName("ccCountry");
            this.Property(t => t.ccphone).HasColumnName("ccphone");
            this.Property(t => t.ccZip).HasColumnName("ccZip");
            this.Property(t => t.ccFirstName).HasColumnName("ccFirstName");
            this.Property(t => t.ccLastName).HasColumnName("ccLastName");
            this.Property(t => t.incident_username).HasColumnName("incident_username");
            this.Property(t => t.acct_rep).HasColumnName("acct_rep");
            this.Property(t => t.orEditDate).HasColumnName("orEditDate");
            this.Property(t => t.orEditor_usrId).HasColumnName("orEditor_usrId");
            this.Property(t => t.orEditor_Username).HasColumnName("orEditor_Username");
            this.Property(t => t.orPrevStatus).HasColumnName("orPrevStatus");
            this.Property(t => t.orCost).HasColumnName("orCost");
            this.Property(t => t.orRollbackDate).HasColumnName("orRollbackDate");
            this.Property(t => t.orRollbackUserID).HasColumnName("orRollbackUserID");
            this.Property(t => t.acct_rep_phone).HasColumnName("acct_rep_phone");
            this.Property(t => t.agentID).HasColumnName("agentID");
            this.Property(t => t.raw1).HasColumnName("raw1");
            this.Property(t => t.raw1serial).HasColumnName("raw1serial");
            this.Property(t => t.raw2).HasColumnName("raw2");
            this.Property(t => t.raw2serial).HasColumnName("raw2serial");
            this.Property(t => t.raw3).HasColumnName("raw3");
            this.Property(t => t.raw3serial).HasColumnName("raw3serial");
            this.Property(t => t.orShipEmail).HasColumnName("orShipEmail");
            this.Property(t => t.postedcc).HasColumnName("postedcc");
        }
    }
}
