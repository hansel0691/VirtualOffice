namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class username1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "BusinessName");
            DropColumn("dbo.Users", "Address1");
            DropColumn("dbo.Users", "Address2");
            DropColumn("dbo.Users", "ZipCode");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Comission");
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Comission", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "ZipCode", c => c.String());
            AddColumn("dbo.Users", "Address2", c => c.String());
            AddColumn("dbo.Users", "Address1", c => c.String());
            AddColumn("dbo.Users", "BusinessName", c => c.String());
        }
    }
}
