namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_filter_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserFilters", "Name", c => c.String());
            AddColumn("dbo.PredefinedFilters", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PredefinedFilters", "Name");
            DropColumn("dbo.UserFilters", "Name");
        }
    }
}
