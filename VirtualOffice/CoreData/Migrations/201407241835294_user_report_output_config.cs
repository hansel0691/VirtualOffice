namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_report_output_config : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReports", "OutputConfiguration", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserReports", "OutputConfiguration");
        }
    }
}
