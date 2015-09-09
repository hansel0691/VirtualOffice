namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_token_and_apiuser_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApiUsers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ApiKey = c.String(nullable: false, maxLength: 50),
                        Secret = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        value = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.ApiUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tokens", "UserId", "dbo.ApiUsers");
            DropIndex("dbo.Tokens", new[] { "UserId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.ApiUsers");
        }
    }
}
