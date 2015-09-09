namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_stand_alone : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportLabelDetails", "Report_Id", "dbo.Reports");
            DropIndex("dbo.ReportLabelDetails", new[] { "Report_Id" });
            AddColumn("dbo.Reports", "IsStandAlone", c => c.Boolean(nullable: false));
            DropTable("dbo.ReportLabelDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReportLabelDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldName = c.String(nullable: false),
                        FieldLabel = c.String(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                        Report_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Reports", "IsStandAlone");
            CreateIndex("dbo.ReportLabelDetails", "Report_Id");
            AddForeignKey("dbo.ReportLabelDetails", "Report_Id", "dbo.Reports", "Id", cascadeDelete: true);
        }
    }
}
