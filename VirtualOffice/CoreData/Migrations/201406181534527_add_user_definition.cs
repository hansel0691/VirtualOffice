namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_user_definition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    RefId = c.Int(nullable: false),
                    Category = c.Int(nullable: false),
                    RowVersion = c.Binary(),
                    TimeSpan = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new {t.RefId, t.Category}, unique: true);
            
            CreateTable(
                "dbo.UserReports",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ReportId = c.Int(nullable: false),
                        Output = c.String(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ReportId })
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserReports", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserReports", "ReportId", "dbo.Reports");
            DropIndex("dbo.UserReports", new[] { "ReportId" });
            DropIndex("dbo.UserReports", new[] { "UserId" });
            DropTable("dbo.UserReports");
            DropTable("dbo.Users");
        }
    }
}
