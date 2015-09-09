namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_user_filters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReportFilter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColunmName = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                        UserReport_UserId = c.Int(),
                        UserReport_ReportId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserReports", t => new { t.UserReport_UserId, t.UserReport_ReportId })
                .Index(t => new { t.UserReport_UserId, t.UserReport_ReportId });
            
            CreateTable(
                "dbo.UserReportFilterValue",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                        UserReportFilter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserReportFilter", t => t.UserReportFilter_Id)
                .Index(t => t.UserReportFilter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" }, "dbo.UserReports");
            DropForeignKey("dbo.UserReportFilterValue", "UserReportFilter_Id", "dbo.UserReportFilter");
            DropIndex("dbo.UserReportFilterValue", new[] { "UserReportFilter_Id" });
            DropIndex("dbo.UserReportFilter", new[] { "UserReport_UserId", "UserReport_ReportId" });
            DropTable("dbo.UserReportFilterValue");
            DropTable("dbo.UserReportFilter");
        }
    }
}
