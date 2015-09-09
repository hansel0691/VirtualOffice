namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class indexColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "IndexColumnName", c => c.String());
            AddColumn("dbo.ReportToReportRel", "IndexParamName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReportToReportRel", "IndexParamName");
            DropColumn("dbo.Reports", "IndexColumnName");
        }
    }
}
