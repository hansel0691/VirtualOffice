namespace CoreData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f_key : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserReportFilterValue", name: "UserReportFilter_Id", newName: "UserReportFilterId");
            RenameIndex(table: "dbo.UserReportFilterValue", name: "IX_UserReportFilter_Id", newName: "IX_UserReportFilterId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserReportFilterValue", name: "IX_UserReportFilterId", newName: "IX_UserReportFilter_Id");
            RenameColumn(table: "dbo.UserReportFilterValue", name: "UserReportFilterId", newName: "UserReportFilter_Id");
        }
    }
}
