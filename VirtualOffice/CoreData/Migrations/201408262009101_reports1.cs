namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reports1 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.ReportModels", newName: "Reports");
            //AlterColumn("dbo.Reports", "Name", c => c.String(nullable: false, maxLength: 200));
            //AlterColumn("dbo.Reports", "Query", c => c.String(nullable: false));
            //AlterColumn("dbo.Reports", "Output", c => c.String(nullable: false));
            //AlterColumn("dbo.Reports", "DefaultOutput", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Reports", "DefaultOutput", c => c.String());
            //AlterColumn("dbo.Reports", "Output", c => c.String());
            //AlterColumn("dbo.Reports", "Query", c => c.String());
            //AlterColumn("dbo.Reports", "Name", c => c.String());
            //RenameTable(name: "dbo.Reports", newName: "ReportModels");
        }
    }
}
