namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_token_table : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tokens", name: "UserId", newName: "ApiUserId");
            RenameIndex(table: "dbo.Tokens", name: "IX_UserId", newName: "IX_ApiUserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tokens", name: "IX_ApiUserId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Tokens", name: "ApiUserId", newName: "UserId");
        }
    }
}
