namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_name_predifined_filters : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PredefinedFilters", "ColumnName", c => c.String(nullable: false));
            AddColumn("dbo.PredefinedFilters", "ParameterName", c => c.String(nullable: false));
            DropColumn("dbo.PredefinedFilters", "FieldName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PredefinedFilters", "FieldName", c => c.String(nullable: false));
            DropColumn("dbo.PredefinedFilters", "ParameterName");
            DropColumn("dbo.PredefinedFilters", "ColumnName");
        }
    }
}
