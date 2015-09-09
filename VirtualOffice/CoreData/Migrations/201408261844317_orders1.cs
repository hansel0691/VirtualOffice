namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        StockAmount = c.Int(),
                        ReservedAmount = c.Int(),
                        MinAmount = c.Int(),
                        MeasureId = c.Int(),
                        Cost = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Status = c.Byte(),
                        Weight = c.Double(),
                        WeightId = c.Int(),
                        Lenght = c.Double(),
                        Height = c.Double(),
                        Width = c.Double(),
                        DimentionId = c.Int(),
                        ItemId = c.String(),
                        Type = c.Int(),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        AgentComm = c.Decimal(precision: 18, scale: 2),
                        DistComm = c.Decimal(precision: 18, scale: 2),
                        MDistComm = c.Decimal(precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressOne = c.String(),
                        AddressTwo = c.String(),
                        AptoNumber = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ShippingInfo_Id", c => c.Int());
            AddColumn("dbo.Orders", "User_Id", c => c.Int());
            AddColumn("dbo.OrderItems", "Item_Id", c => c.Int());
            CreateIndex("dbo.Orders", "ShippingInfo_Id");
            CreateIndex("dbo.Orders", "User_Id");
            CreateIndex("dbo.OrderItems", "Item_Id");
            AddForeignKey("dbo.OrderItems", "Item_Id", "dbo.InventoryItems", "Id");
            AddForeignKey("dbo.Orders", "ShippingInfo_Id", "dbo.ShippingInfoes", "Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.OrderItems", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItems", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Orders", "ShippingInfo_Id", "dbo.ShippingInfoes");
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.InventoryItems");
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "ShippingInfo_Id" });
            DropColumn("dbo.OrderItems", "Item_Id");
            DropColumn("dbo.Orders", "User_Id");
            DropColumn("dbo.Orders", "ShippingInfo_Id");
            DropTable("dbo.ShippingInfoes");
            DropTable("dbo.InventoryItems");
        }
    }
}
