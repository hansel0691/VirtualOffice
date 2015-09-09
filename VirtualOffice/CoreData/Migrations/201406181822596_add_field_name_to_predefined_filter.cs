namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_field_name_to_predefined_filter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PredefinedFilters", "FieldName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PredefinedFilters", "FieldName");
        }
    }
}
