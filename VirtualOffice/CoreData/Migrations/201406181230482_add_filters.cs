namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_filters : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Filters", newName: "UserFilters");
            DropForeignKey("dbo.ReportFilter", "FilterId", "dbo.Filters");
            DropForeignKey("dbo.ReportFilter", "ReportId", "dbo.Reports");
            DropIndex("dbo.ReportFilter", new[] { "ReportId" });
            DropIndex("dbo.ReportFilter", new[] { "FilterId" });
            CreateTable(
                "dbo.PredefinedFilters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reports", "Output", c => c.String());
            DropColumn("dbo.Reports", "DefaultConfiguration");
            DropColumn("dbo.UserFilters", "Name");
            DropTable("dbo.ReportFilter");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReportFilter",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.FilterId });
            
            AddColumn("dbo.UserFilters", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Reports", "DefaultConfiguration", c => c.String());
            DropColumn("dbo.Reports", "Output");
            DropTable("dbo.PredefinedFilters");
            CreateIndex("dbo.ReportFilter", "FilterId");
            CreateIndex("dbo.ReportFilter", "ReportId");
            AddForeignKey("dbo.ReportFilter", "ReportId", "dbo.Reports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReportFilter", "FilterId", "dbo.Filters", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.UserFilters", newName: "Filters");
        }
    }
}
