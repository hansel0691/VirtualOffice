namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_filter_max_length : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "UserFilters", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "UserFilters");
        }
    }
}
