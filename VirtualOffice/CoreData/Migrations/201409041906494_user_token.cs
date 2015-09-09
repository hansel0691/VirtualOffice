namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_token : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HashKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hash = c.String(),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        TimeSpan = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HashKeys", "User_Id", "dbo.Users");
            DropIndex("dbo.HashKeys", new[] { "User_Id" });
            DropTable("dbo.HashKeys");
        }
    }
}
