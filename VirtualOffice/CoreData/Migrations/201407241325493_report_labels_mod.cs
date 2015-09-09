namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_labels_mod : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ReportLabels", name: "Report_Id", newName: "ReportId");
            RenameIndex(table: "dbo.ReportLabels", name: "IX_Report_Id", newName: "IX_ReportId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ReportLabels", name: "IX_ReportId", newName: "IX_Report_Id");
            RenameColumn(table: "dbo.ReportLabels", name: "ReportId", newName: "Report_Id");
        }
    }
}
