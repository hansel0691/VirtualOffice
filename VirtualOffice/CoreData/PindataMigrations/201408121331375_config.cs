namespace CoreData.PindataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class config : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.view_opened_leads", "RowVersion");
            //DropColumn("dbo.view_opened_leads", "TimeSpan");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.view_opened_leads", "TimeSpan", c => c.DateTime(nullable: false));
            //AddColumn("dbo.view_opened_leads", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
