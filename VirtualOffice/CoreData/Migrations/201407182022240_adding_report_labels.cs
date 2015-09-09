namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_report_labels : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reports", t => t.Report_Id, cascadeDelete: true)
                .Index(t => t.Report_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReportLabelDetails", "Report_Id", "dbo.Reports");
            DropIndex("dbo.ReportLabelDetails", new[] { "Report_Id" });
            DropTable("dbo.ReportLabelDetails");
        }
    }
}
