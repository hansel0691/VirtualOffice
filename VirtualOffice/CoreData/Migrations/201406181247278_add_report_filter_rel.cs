namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_report_filter_rel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportPredefinedFilterRels",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.FilterId })
                .ForeignKey("dbo.PredefinedFilters", t => t.FilterId, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.FilterId);
            
            CreateTable(
                "dbo.ReportUserFilterRels",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.FilterId })
                .ForeignKey("dbo.UserFilters", t => t.FilterId, cascadeDelete: true)
                .ForeignKey("dbo.Reports", t => t.ReportId, cascadeDelete: true)
                .Index(t => t.ReportId)
                .Index(t => t.FilterId);
            
            AddColumn("dbo.PredefinedFilters", "Value", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportUserFilterRels", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportUserFilterRels", "FilterId", "dbo.UserFilters");
            DropForeignKey("dbo.ReportPredefinedFilterRels", "ReportId", "dbo.Reports");
            DropForeignKey("dbo.ReportPredefinedFilterRels", "FilterId", "dbo.PredefinedFilters");
            DropIndex("dbo.ReportUserFilterRels", new[] { "FilterId" });
            DropIndex("dbo.ReportUserFilterRels", new[] { "ReportId" });
            DropIndex("dbo.ReportPredefinedFilterRels", new[] { "FilterId" });
            DropIndex("dbo.ReportPredefinedFilterRels", new[] { "ReportId" });
            DropColumn("dbo.PredefinedFilters", "Value");
            DropTable("dbo.ReportUserFilterRels");
            DropTable("dbo.ReportPredefinedFilterRels");
        }
    }
}
