namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_report_dates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReports", "StartDate", c => c.DateTime());
            AddColumn("dbo.UserReports", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserReports", "EndDate");
            DropColumn("dbo.UserReports", "StartDate");
        }
    }
}
