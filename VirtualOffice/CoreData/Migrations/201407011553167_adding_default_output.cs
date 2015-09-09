namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_default_output : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "DefaultOutput", c => c.String(nullable: false));
            AlterColumn("dbo.Reports", "Output", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reports", "Output", c => c.String());
            DropColumn("dbo.Reports", "DefaultOutput");
        }
    }
}
