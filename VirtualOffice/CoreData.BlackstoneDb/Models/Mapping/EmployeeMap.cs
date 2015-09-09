using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Blackstone;

namespace CoreData.BlackstoneDb.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            this.Ignore(t => t.RowVersion);
            this.Ignore(t => t.TimeSpan);

            // Primary Key
            this.HasKey(t => t.Employee_ID);

            // Properties
            this.Property(t => t.FirstName)
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(1);

            this.Property(t => t.LastName)
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .HasMaxLength(50);

            this.Property(t => t.Unit)
                .HasMaxLength(10);

            this.Property(t => t.City)
                .HasMaxLength(50);

            this.Property(t => t.State)
                .HasMaxLength(2);

            this.Property(t => t.Zip)
                .HasMaxLength(10);

            this.Property(t => t.HomePhone)
                .HasMaxLength(10);

            this.Property(t => t.CellularPhone)
                .HasMaxLength(10);

            this.Property(t => t.PagerNumber)
                .HasMaxLength(10);

            this.Property(t => t.FaxNumber)
                .HasMaxLength(10);

            this.Property(t => t.PersonalEmail)
                .HasMaxLength(50);

            this.Property(t => t.BlackstoneEmail)
                .HasMaxLength(50);

            this.Property(t => t.RadioID)
                .HasMaxLength(10);

            this.Property(t => t.ExtensionNumber)
                .HasMaxLength(10);

            this.Property(t => t.DepartmentCode)
                .HasMaxLength(15);

            this.Property(t => t.DepartmentName)
                .HasMaxLength(50);

            this.Property(t => t.ManagerName)
                .HasMaxLength(50);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.ZoneCode)
                .HasMaxLength(2);

            this.Property(t => t.Notes)
                .HasMaxLength(2000);

            this.Property(t => t.UserEditor)
                .HasMaxLength(20);

            this.Property(t => t.SSN)
                .HasMaxLength(9);

            this.Property(t => t.HandKey)
                .HasMaxLength(50);

            this.Property(t => t.IDBadge)
                .HasMaxLength(50);

            this.Property(t => t.Computer)
                .HasMaxLength(50);

            this.Property(t => t.PhoneExt)
                .HasMaxLength(50);

            this.Property(t => t.PrinterLoc)
                .HasMaxLength(50);

            this.Property(t => t.PrinterNT)
                .HasMaxLength(50);

            this.Property(t => t.Instr)
                .HasMaxLength(500);

            this.Property(t => t.Signature)
                .HasMaxLength(50);

            this.Property(t => t.networkuser)
                .HasMaxLength(50);

            this.Property(t => t.PaymentType)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyContactFirstName)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyContactLastName)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyContactRelationship)
                .HasMaxLength(50);

            this.Property(t => t.EmergencyContactPhone1)
                .HasMaxLength(10);

            this.Property(t => t.EmergencyContactPhone2)
                .HasMaxLength(10);

            this.Property(t => t.Relative1FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Relative1LastName)
                .HasMaxLength(50);

            this.Property(t => t.Relative1Relationship)
                .HasMaxLength(50);

            this.Property(t => t.Relative1Phone1)
                .HasMaxLength(10);

            this.Property(t => t.Relative1Phone2)
                .HasMaxLength(10);

            this.Property(t => t.Relative2FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Relative2LastName)
                .HasMaxLength(50);

            this.Property(t => t.Relative2Relationship)
                .HasMaxLength(50);

            this.Property(t => t.Relative2Phone1)
                .HasMaxLength(10);

            this.Property(t => t.Relative2Phone2)
                .HasMaxLength(10);

            this.Property(t => t.Relative3FirstName)
                .HasMaxLength(50);

            this.Property(t => t.Relative3LastName)
                .HasMaxLength(50);

            this.Property(t => t.Relative3Relationship)
                .HasMaxLength(50);

            this.Property(t => t.Relative3Phone1)
                .HasMaxLength(10);

            this.Property(t => t.Relative3Phone2)
                .HasMaxLength(50);

            this.Property(t => t.DriverLicenseState)
                .HasMaxLength(2);

            this.Property(t => t.DriverLicenseNumber)
                .HasMaxLength(25);

            this.Property(t => t.DriverLicenseTrack)
                .HasMaxLength(20);

            this.Property(t => t.Company)
                .HasMaxLength(50);

            this.Property(t => t.TerminationReason)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(t => t.Employee_ID).HasColumnName("Employee_ID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Unit).HasColumnName("Unit");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.Zip).HasColumnName("Zip");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.HomePhone).HasColumnName("HomePhone");
            this.Property(t => t.CellularPhone).HasColumnName("CellularPhone");
            this.Property(t => t.PagerNumber).HasColumnName("PagerNumber");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.PersonalEmail).HasColumnName("PersonalEmail");
            this.Property(t => t.BlackstoneEmail).HasColumnName("BlackstoneEmail");
            this.Property(t => t.RadioID).HasColumnName("RadioID");
            this.Property(t => t.ExtensionNumber).HasColumnName("ExtensionNumber");
            this.Property(t => t.DateOfHire).HasColumnName("DateOfHire");
            this.Property(t => t.DepartmentCode).HasColumnName("DepartmentCode");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.Manager_Id).HasColumnName("Manager_Id");
            this.Property(t => t.ManagerName).HasColumnName("ManagerName");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PersonalDaysBeginningDate).HasColumnName("PersonalDaysBeginningDate");
            this.Property(t => t.VacationBeginningDate).HasColumnName("VacationBeginningDate");
            this.Property(t => t.TenDaysVacationBeginningDate).HasColumnName("TenDaysVacationBeginningDate");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.PersonalDay1).HasColumnName("PersonalDay1");
            this.Property(t => t.PersonalDay2).HasColumnName("PersonalDay2");
            this.Property(t => t.PersonalDay3).HasColumnName("PersonalDay3");
            this.Property(t => t.VacationDay1).HasColumnName("VacationDay1");
            this.Property(t => t.VacationDay2).HasColumnName("VacationDay2");
            this.Property(t => t.VacationDay3).HasColumnName("VacationDay3");
            this.Property(t => t.VacationDay4).HasColumnName("VacationDay4");
            this.Property(t => t.VacationDay5).HasColumnName("VacationDay5");
            this.Property(t => t.VacationDay6).HasColumnName("VacationDay6");
            this.Property(t => t.VacationDay7).HasColumnName("VacationDay7");
            this.Property(t => t.VacationDay8).HasColumnName("VacationDay8");
            this.Property(t => t.VacationDay9).HasColumnName("VacationDay9");
            this.Property(t => t.VacationDay10).HasColumnName("VacationDay10");
            this.Property(t => t.NonCompete).HasColumnName("NonCompete");
            this.Property(t => t.ZoneCode).HasColumnName("ZoneCode");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.TerminationDate).HasColumnName("TerminationDate");
            this.Property(t => t.UserEditor).HasColumnName("UserEditor");
            this.Property(t => t.DateEdited).HasColumnName("DateEdited");
            this.Property(t => t.SSN).HasColumnName("SSN");
            this.Property(t => t.HandKey).HasColumnName("HandKey");
            this.Property(t => t.IDBadge).HasColumnName("IDBadge");
            this.Property(t => t.Computer).HasColumnName("Computer");
            this.Property(t => t.PhoneExt).HasColumnName("PhoneExt");
            this.Property(t => t.PrinterLoc).HasColumnName("PrinterLoc");
            this.Property(t => t.PrinterNT).HasColumnName("PrinterNT");
            this.Property(t => t.Instr).HasColumnName("Instr");
            this.Property(t => t.Signature).HasColumnName("Signature");
            this.Property(t => t.networkuser).HasColumnName("networkuser");
            this.Property(t => t.PaymentType).HasColumnName("PaymentType");
            this.Property(t => t.MaxHoursPerDay).HasColumnName("MaxHoursPerDay");
            this.Property(t => t.ShiftType).HasColumnName("ShiftType");
            this.Property(t => t.IsOpenSchedule).HasColumnName("IsOpenSchedule");
            this.Property(t => t.EmergencyContactFirstName).HasColumnName("EmergencyContactFirstName");
            this.Property(t => t.EmergencyContactLastName).HasColumnName("EmergencyContactLastName");
            this.Property(t => t.EmergencyContactRelationship).HasColumnName("EmergencyContactRelationship");
            this.Property(t => t.EmergencyContactPhone1).HasColumnName("EmergencyContactPhone1");
            this.Property(t => t.EmergencyContactPhone2).HasColumnName("EmergencyContactPhone2");
            this.Property(t => t.Relative1FirstName).HasColumnName("Relative1FirstName");
            this.Property(t => t.Relative1LastName).HasColumnName("Relative1LastName");
            this.Property(t => t.Relative1Relationship).HasColumnName("Relative1Relationship");
            this.Property(t => t.Relative1Phone1).HasColumnName("Relative1Phone1");
            this.Property(t => t.Relative1Phone2).HasColumnName("Relative1Phone2");
            this.Property(t => t.Relative2FirstName).HasColumnName("Relative2FirstName");
            this.Property(t => t.Relative2LastName).HasColumnName("Relative2LastName");
            this.Property(t => t.Relative2Relationship).HasColumnName("Relative2Relationship");
            this.Property(t => t.Relative2Phone1).HasColumnName("Relative2Phone1");
            this.Property(t => t.Relative2Phone2).HasColumnName("Relative2Phone2");
            this.Property(t => t.Relative3FirstName).HasColumnName("Relative3FirstName");
            this.Property(t => t.Relative3LastName).HasColumnName("Relative3LastName");
            this.Property(t => t.Relative3Relationship).HasColumnName("Relative3Relationship");
            this.Property(t => t.Relative3Phone1).HasColumnName("Relative3Phone1");
            this.Property(t => t.Relative3Phone2).HasColumnName("Relative3Phone2");
            this.Property(t => t.DriverLicenseState).HasColumnName("DriverLicenseState");
            this.Property(t => t.DriverLicenseNumber).HasColumnName("DriverLicenseNumber");
            this.Property(t => t.DriverLicenseTrack).HasColumnName("DriverLicenseTrack");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.EthnicGroup).HasColumnName("EthnicGroup");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.ReceiveIncidents).HasColumnName("ReceiveIncidents");
            this.Property(t => t.TerminationReason).HasColumnName("TerminationReason");
            this.Property(t => t.Agent_ID).HasColumnName("Agent_ID");
        }
    }
}
