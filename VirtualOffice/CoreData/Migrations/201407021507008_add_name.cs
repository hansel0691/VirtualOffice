namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserReports", "Name", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserReports", "Name");
        }
    }
}
