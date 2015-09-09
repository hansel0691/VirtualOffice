namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class soft_delete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" }, "dbo.UserReports");
            DropForeignKey("dbo.UserReportFilterValue", "UserReportFilter_Id", "dbo.UserReportFilter");
            DropIndex("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" });
            DropIndex("dbo.UserReportFilterValue", new[] { "UserReportFilter_Id" });
            AddColumn("dbo.UserReportFilter", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.UserReportFilter", "UserReport_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserReportFilter", "UserReport_ReportId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserReportFilterValue", "UserReportFilter_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" });
            CreateIndex("dbo.UserReportFilterValue", "UserReportFilter_Id");
            AddForeignKey("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" }, "dbo.UserReports", new[] { "UserId", "ReportId" }, cascadeDelete: true);
            AddForeignKey("dbo.UserReportFilterValue", "UserReportFilter_Id", "dbo.UserReportFilter", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReportFilterValue", "UserReportFilter_Id", "dbo.UserReportFilter");
            DropForeignKey("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" }, "dbo.UserReports");
            DropIndex("dbo.UserReportFilterValue", new[] { "UserReportFilter_Id" });
            DropIndex("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" });
            AlterColumn("dbo.UserReportFilterValue", "UserReportFilter_Id", c => c.Int());
            AlterColumn("dbo.UserReportFilter", "UserReport_ReportId", c => c.Int());
            AlterColumn("dbo.UserReportFilter", "UserReport_UserId", c => c.Int());
            DropColumn("dbo.UserReportFilter", "Deleted");
            CreateIndex("dbo.UserReportFilterValue", "UserReportFilter_Id");
            CreateIndex("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" });
            AddForeignKey("dbo.UserReportFilterValue", "UserReportFilter_Id", "dbo.UserReportFilter", "Id");
            AddForeignKey("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" }, "dbo.UserReports", new[] { "UserId", "ReportId" });
        }
    }
}
