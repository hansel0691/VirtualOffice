namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removing_user_filter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportUserFilterRels", "FilterId", "dbo.UserFilters");
            DropForeignKey("dbo.ReportUserFilterRels", "ReportId", "dbo.Reports");
            DropIndex("dbo.ReportUserFilterRels", new[] { "ReportId" });
            DropIndex("dbo.ReportUserFilterRels", new[] { "FilterId" });
            DropTable("dbo.ReportUserFilterRels");
            DropTable("dbo.UserFilters");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserFilters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 200),
                        FilterOptions = c.String(),
                        Name = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReportUserFilterRels",
                c => new
                    {
                        ReportId = c.Int(nullable: false),
                        FilterId = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.ReportId, t.FilterId });
            
            CreateIndex("dbo.ReportUserFilterRels", "FilterId");
            CreateIndex("dbo.ReportUserFilterRels", "ReportId");
            AddForeignKey("dbo.ReportUserFilterRels", "ReportId", "dbo.Reports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReportUserFilterRels", "FilterId", "dbo.UserFilters", "Id", cascadeDelete: true);
        }
    }
}
