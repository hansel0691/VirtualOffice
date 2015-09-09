namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class optimistic_concurrence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApiUsers", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Tokens", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.PredefinedFilters", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.ReportPredefinedFilterRels", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Reports", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.ReportUserFilterRels", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.UserFilters", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.UserReports", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Users", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.UserTypes", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.ReportToReportRel", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportToReportRel", "RowVersion");
            DropColumn("dbo.UserTypes", "RowVersion");
            DropColumn("dbo.Users", "RowVersion");
            DropColumn("dbo.UserReports", "RowVersion");
            DropColumn("dbo.UserFilters", "RowVersion");
            DropColumn("dbo.ReportUserFilterRels", "RowVersion");
            DropColumn("dbo.Reports", "RowVersion");
            DropColumn("dbo.ReportPredefinedFilterRels", "RowVersion");
            DropColumn("dbo.PredefinedFilters", "RowVersion");
            DropColumn("dbo.Tokens", "RowVersion");
            DropColumn("dbo.ApiUsers", "RowVersion");
        }
    }
}
