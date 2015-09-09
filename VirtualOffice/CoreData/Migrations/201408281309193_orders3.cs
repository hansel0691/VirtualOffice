namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.InventoryItems");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingInfo_Id", "dbo.ShippingInfoes");
            DropIndex("dbo.Orders", new[] { "ShippingInfo_Id" });
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            AddColumn("dbo.Orders", "CartHeaderId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ShippingInfo_Id");
            DropTable("dbo.OrderItems");
            DropTable("dbo.InventoryItems");
            DropTable("dbo.ShippingInfoes");
        }
        
        public override void Down()
        {
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
            
            CreateTable(
                "dbo.InventoryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefId = c.Int(nullable: false),
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
                        Length = c.Double(),
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
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                        Item_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ShippingInfo_Id", c => c.Int());
            DropColumn("dbo.Orders", "CartHeaderId");
            CreateIndex("dbo.OrderItems", "Order_Id");
            CreateIndex("dbo.OrderItems", "Item_Id");
            CreateIndex("dbo.Orders", "ShippingInfo_Id");
            AddForeignKey("dbo.Orders", "ShippingInfo_Id", "dbo.ShippingInfoes", "Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderItems", "Item_Id", "dbo.InventoryItems", "Id");
        }
    }
}
