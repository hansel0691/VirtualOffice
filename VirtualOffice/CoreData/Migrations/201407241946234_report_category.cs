namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class report_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "Category");
        }
    }
}
