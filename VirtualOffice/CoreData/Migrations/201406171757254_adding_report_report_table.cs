namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_report_report_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportToReportRel",
                c => new
                    {
                        FromId = c.Int(nullable: false),
                        ToId = c.Int(nullable: false),
                        DependencyProperty = c.String(nullable:false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.FromId, t.ToId })
                .ForeignKey("dbo.Reports", t => t.FromId, cascadeDelete: false)
                .ForeignKey("dbo.Reports", t => t.ToId, cascadeDelete: false)
                .Index(t => t.FromId)
                .Index(t => t.ToId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportToReportRel", "ToId", "dbo.Reports");
            DropForeignKey("dbo.ReportToReportRel", "FromId", "dbo.Reports");
            DropIndex("dbo.ReportToReportRel", new[] { "ToId" });
            DropIndex("dbo.ReportToReportRel", new[] { "FromId" });
            DropTable("dbo.ReportToReportRel");
        }
    }
}
