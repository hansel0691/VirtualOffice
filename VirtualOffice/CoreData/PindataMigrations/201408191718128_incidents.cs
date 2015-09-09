namespace CoreData.PindataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class incidents : DbMigration
    {
        public override void Up()
        {
        //    CreateTable(
        //        "dbo.incidents_view",
        //        c => new
        //            {
        //                ID = c.Int(nullable: false, identity: true),
        //                agent_id = c.Int(nullable: false),
        //                customer_id = c.Int(nullable: false),
        //                Merchant = c.String(),
        //                IncidentType = c.String(name: "Incident Type"),
        //                IncidentStatus = c.String(name: "Incident Status"),
        //                TerminalId = c.Int(name: "Terminal Id", nullable: false),
        //                DateOpened = c.DateTime(name: "Date Opened"),
        //                DateClosed = c.DateTime(name: "Date Closed"),
        //            })
        //        .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.incidents_view");
        }
    }
}
