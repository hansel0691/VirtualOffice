namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BusinessName", c => c.String());
            AddColumn("dbo.Users", "Address1", c => c.String());
            AddColumn("dbo.Users", "Address2", c => c.String());
            AddColumn("dbo.Users", "ZipCode", c => c.String());
            AddColumn("dbo.Users", "State", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "Comission", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Comission");
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "State");
            DropColumn("dbo.Users", "ZipCode");
            DropColumn("dbo.Users", "Address2");
            DropColumn("dbo.Users", "Address1");
            DropColumn("dbo.Users", "BusinessName");
        }
    }
}
