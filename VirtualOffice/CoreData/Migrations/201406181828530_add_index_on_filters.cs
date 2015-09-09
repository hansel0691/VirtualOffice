namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_index_on_filters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.PredefinedFilters", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PredefinedFilters", "Name", c => c.String());
            DropColumn("dbo.Reports", "Name");
        }
    }
}
