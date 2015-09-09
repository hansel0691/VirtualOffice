namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_filters : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserFilterOptionsRels", "OptionId", "dbo.UserFilterOptions");
            DropForeignKey("dbo.UserFilterOptionsRels", "UserFilterId", "dbo.UserFilters");
            DropIndex("dbo.UserFilterOptionsRels", new[] { "UserFilterId" });
            DropIndex("dbo.UserFilterOptionsRels", new[] { "OptionId" });
            AddColumn("dbo.UserFilters", "FilterOptions", c => c.String());
            DropTable("dbo.UserFilterOptions");
            DropTable("dbo.UserFilterOptionsRels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserFilterOptionsRels",
                c => new
                    {
                        UserFilterId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserFilterId, t.OptionId });
            
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
            
            DropColumn("dbo.UserFilters", "FilterOptions");
            CreateIndex("dbo.UserFilterOptionsRels", "OptionId");
            CreateIndex("dbo.UserFilterOptionsRels", "UserFilterId");
            AddForeignKey("dbo.UserFilterOptionsRels", "UserFilterId", "dbo.UserFilters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserFilterOptionsRels", "OptionId", "dbo.UserFilterOptions", "Id", cascadeDelete: true);
        }
    }
}
