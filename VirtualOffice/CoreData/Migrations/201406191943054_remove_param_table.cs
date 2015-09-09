namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_param_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReportParam", "ParameterId", "dbo.Parameters");
            DropForeignKey("dbo.ReportParam", "ReportId", "dbo.Reports");
          //  DropIndex("dbo.ReportParam", new[] { "ReportId" });
          ////  DropIndex("dbo.ReportParam", new[] { "ParameterId" });
          //  AlterColumn("dbo.Reports", "Name", c => c.String(nullable: false, maxLength: 200));
          //  AlterColumn("dbo.PredefinedFilters", "Name", c => c.String(nullable: false, maxLength: 200));
          //  AlterColumn("dbo.UserFilters", "Label", c => c.String(nullable: false, maxLength: 200));
            DropTable("dbo.Parameters");
            DropTable("dbo.ReportParam");
        }
        
        public override void Down()
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
                .PrimaryKey(t => new { t.ReportId, t.ParameterId });
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.UserFilters", "Label", c => c.String(nullable: false));
            AlterColumn("dbo.PredefinedFilters", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reports", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.ReportParam", "ParameterId");
            CreateIndex("dbo.ReportParam", "ReportId");
            AddForeignKey("dbo.ReportParam", "ReportId", "dbo.Reports", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReportParam", "ParameterId", "dbo.Parameters", "Id", cascadeDelete: true);
        }
    }
}
