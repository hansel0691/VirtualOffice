namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_report_parameters_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportParam",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        ParameterId = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.ParameterId })
                .ForeignKey("dbo.Parameters", t => t.ParameterId, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.ParameterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportParam", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportParam", "ParameterId", "dbo.Parameters");
            DropIndex("dbo.ReportParam", new[] { "ParameterId" });
            DropIndex("dbo.ReportParam", new[] { "ReportId" });
            DropTable("dbo.ReportParam");
        }
    }
}
