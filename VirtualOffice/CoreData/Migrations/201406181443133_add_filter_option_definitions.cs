namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_filter_option_definitions : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => new { t.UserFilterId, t.OptionId })
                .ForeignKey("dbo.UserFilterOptions", t => t.OptionId, cascadeDelete: true)
                .ForeignKey("dbo.UserFilters", t => t.UserFilterId, cascadeDelete: true)
                .Index(t => t.UserFilterId)
                .Index(t => t.OptionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFilterOptionsRels", "UserFilterId", "dbo.UserFilters");
            DropForeignKey("dbo.UserFilterOptionsRels", "OptionId", "dbo.UserFilterOptions");
            DropIndex("dbo.UserFilterOptionsRels", new[] { "OptionId" });
            DropIndex("dbo.UserFilterOptionsRels", new[] { "UserFilterId" });
            DropTable("dbo.UserFilterOptionsRels");
        }
    }
}
