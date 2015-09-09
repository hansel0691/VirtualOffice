namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_filter_definitions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFilterOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserFilters", "Label", c => c.String(nullable: false));
            AddColumn("dbo.PredefinedFilters", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PredefinedFilters", "Type");
            DropColumn("dbo.UserFilters", "Label");
            DropTable("dbo.UserFilterOptions");
        }
    }
}
