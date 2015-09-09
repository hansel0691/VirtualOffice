namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reports : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Reports", newName: "ReportModels");
            //AlterColumn("dbo.ReportModels", "Name", c => c.String());
            //AlterColumn("dbo.ReportModels", "Query", c => c.String());
            //AlterColumn("dbo.ReportModels", "Output", c => c.String());
            //AlterColumn("dbo.ReportModels", "DefaultOutput", c => c.String());
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.ReportModels", "DefaultOutput", c => c.String(nullable: false));
            //AlterColumn("dbo.ReportModels", "Output", c => c.String(nullable: false));
            //AlterColumn("dbo.ReportModels", "Query", c => c.String(nullable: false));
            //AlterColumn("dbo.ReportModels", "Name", c => c.String(nullable: false, maxLength: 200));
            //RenameTable(name: "dbo.ReportModels", newName: "Reports");
        }
    }
}
