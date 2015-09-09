namespace CoreData.PindataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incidents1 : DbMigration
    {
        public override void Up()
        {
          //  AlterColumn("dbo.incidents_view", "Terminal Id", c => c.String());
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.incidents_view", "Terminal Id", c => c.Int(nullable: false));
        }
    }
}
