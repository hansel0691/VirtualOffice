namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "User_Id", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "User_Id" });
            RenameColumn(table: "dbo.Orders", name: "User_Id", newName: "UserId");
            AddColumn("dbo.Orders", "RefId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "CartHeaderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CartHeaderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            AlterColumn("dbo.Orders", "UserId", c => c.Int());
            DropColumn("dbo.Orders", "RefId");
            RenameColumn(table: "dbo.Orders", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Orders", "User_Id");
            AddForeignKey("dbo.Orders", "User_Id", "dbo.Users", "Id");
        }
    }
}
