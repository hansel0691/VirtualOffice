namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_report_config_requiered : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserReports", "OutputConfiguration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserReports", "OutputConfiguration", c => c.String());
        }
    }
}
