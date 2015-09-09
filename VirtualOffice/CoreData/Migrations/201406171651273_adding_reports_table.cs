namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_reports_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Query = c.String(nullable: false),
                        DefaultConfiguration = c.String(),
                        IsEnable = c.Boolean(nullable: false, defaultValue: true),
                        RowVersion = c.Binary(),
                        TimeSpan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reports");
        }
    }
}
