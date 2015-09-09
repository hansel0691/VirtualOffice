namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users1 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE dbo.Users");
            AlterColumn("dbo.Users", "Comission", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Comission", c => c.String());
        }
    }
}
