namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_labels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReportLabels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColumnName = c.String(nullable: false),
                        Label = c.String(nullable: false),
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
            DropForeignKey("dbo.ReportLabels", "Report_Id", "dbo.Reports");
            DropIndex("dbo.ReportLabels", new[] { "Report_Id" });
            DropTable("dbo.ReportLabels");
        }
    }
}
