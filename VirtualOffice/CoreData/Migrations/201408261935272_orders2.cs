namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InventoryItems", "RefId", c => c.Int(nullable: false));
            AddColumn("dbo.InventoryItems", "Length", c => c.Double());
            DropColumn("dbo.InventoryItems", "Lenght");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InventoryItems", "Lenght", c => c.Double());
            DropColumn("dbo.InventoryItems", "Length");
            DropColumn("dbo.InventoryItems", "RefId");
        }
    }
}
