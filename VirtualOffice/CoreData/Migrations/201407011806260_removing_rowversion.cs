namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removing_rowversion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ApiUsers", "RowVersion");
            DropColumn("dbo.Tokens", "RowVersion");
            DropColumn("dbo.PredefinedFilters", "RowVersion");
            DropColumn("dbo.ReportPredefinedFilterRels", "RowVersion");
            DropColumn("dbo.Reports", "RowVersion");
            DropColumn("dbo.ReportUserFilterRels", "RowVersion");
            DropColumn("dbo.UserFilters", "RowVersion");
            DropColumn("dbo.UserReports", "RowVersion");
            DropColumn("dbo.Users", "RowVersion");
            DropColumn("dbo.UserTypes", "RowVersion");
            DropColumn("dbo.ReportToReportRel", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReportToReportRel", "RowVersion", c => c.Binary());
            AddColumn("dbo.UserTypes", "RowVersion", c => c.Binary());
            AddColumn("dbo.Users", "RowVersion", c => c.Binary());
            AddColumn("dbo.UserReports", "RowVersion", c => c.Binary());
            AddColumn("dbo.UserFilters", "RowVersion", c => c.Binary());
            AddColumn("dbo.ReportUserFilterRels", "RowVersion", c => c.Binary());
            AddColumn("dbo.Reports", "RowVersion", c => c.Binary());
            AddColumn("dbo.ReportPredefinedFilterRels", "RowVersion", c => c.Binary());
            AddColumn("dbo.PredefinedFilters", "RowVersion", c => c.Binary());
            AddColumn("dbo.Tokens", "RowVersion", c => c.Binary());
            AddColumn("dbo.ApiUsers", "RowVersion", c => c.Binary());
        }
    }
}
