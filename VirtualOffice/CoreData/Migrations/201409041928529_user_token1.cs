namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_token1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HashKeys", "User_Id", "dbo.Users");
            DropIndex("dbo.HashKeys", new[] { "User_Id" });
            RenameColumn(table: "dbo.HashKeys", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.HashKeys", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.HashKeys", "UserId");
            AddForeignKey("dbo.HashKeys", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HashKeys", "UserId", "dbo.Users");
            DropIndex("dbo.HashKeys", new[] { "UserId" });
            AlterColumn("dbo.HashKeys", "UserId", c => c.Int());
            RenameColumn(table: "dbo.HashKeys", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.HashKeys", "User_Id");
            AddForeignKey("dbo.HashKeys", "User_Id", "dbo.Users", "Id");
        }
    }
}
