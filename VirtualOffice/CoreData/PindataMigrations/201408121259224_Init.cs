namespace CoreData.PindataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Application_Template", "ApplicationId", "dbo.Applications");
            //DropForeignKey("dbo.Application_Template", "TemplateId", "dbo.Templates");
            //DropForeignKey("dbo.Documents", "TemplateId", "dbo.Templates");
            //DropForeignKey("dbo.Forms", "Ticket", "dbo.Tickets");
            //DropForeignKey("dbo.Forms", "TemplateId", "dbo.Templates");
            //DropForeignKey("dbo.Forms_Data", "FormId", "dbo.Forms");
            //DropForeignKey("dbo.Forms_Data", "FieldId", "dbo.Template_Fields");
            //DropForeignKey("dbo.Template_Fields", "TemplateId", "dbo.Templates");
            //DropForeignKey("dbo.Template_Fields_grpOptions", "FieldId", "dbo.Template_Fields");
            //DropForeignKey("dbo.Tokens", "UserId", "dbo.Users");
            //DropIndex("dbo.Application_Template", new[] { "ApplicationId" });
            //DropIndex("dbo.Application_Template", new[] { "TemplateId" });
            //DropIndex("dbo.Documents", new[] { "TemplateId" });
            //DropIndex("dbo.Forms", new[] { "Ticket" });
            //DropIndex("dbo.Forms", new[] { "TemplateId" });
            //DropIndex("dbo.Forms_Data", new[] { "FormId" });
            //DropIndex("dbo.Forms_Data", new[] { "FieldId" });
            //DropIndex("dbo.Template_Fields", new[] { "TemplateId" });
            //DropIndex("dbo.Template_Fields_grpOptions", new[] { "FieldId" });
            //DropIndex("dbo.Tokens", new[] { "UserId" });
            //CreateTable(
            //    "dbo.view_opened_leads",
            //    c => new
            //        {
            //            Lead = c.Int(name: "Lead#", nullable: false, identity: true),
            //            createdBy = c.String(),
            //            leadSource = c.String(),
            //            RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
            //            TimeSpan = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Lead);
            
            //DropTable("dbo.Application_Template");
            //DropTable("dbo.Applications");
            //DropTable("dbo.Templates");
            //DropTable("dbo.Documents");
            //DropTable("dbo.Forms");
            //DropTable("dbo.Forms_Data");
            //DropTable("dbo.Template_Fields");
            //DropTable("dbo.Template_Fields_grpOptions");
            //DropTable("dbo.Tickets");
            //DropTable("dbo.Log");
            //DropTable("dbo.sysdiagrams");
            //DropTable("dbo.Tokens");
            //DropTable("dbo.Users");
        }
        
        public override void Down()
        {
            //CreateTable(
            //    "dbo.Users",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            ApiKey = c.String(nullable: false, maxLength: 50),
            //            Secret = c.String(nullable: false, maxLength: 50),
            //            UserName = c.String(nullable: false, maxLength: 50),
            //            Password = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Tokens",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            value = c.String(nullable: false, maxLength: 50),
            //            UserId = c.Int(nullable: false),
            //            ExpirationDate = c.DateTime(nullable: false),
            //            IsActive = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.sysdiagrams",
            //    c => new
            //        {
            //            diagram_id = c.Int(nullable: false, identity: true),
            //            name = c.String(nullable: false, maxLength: 128),
            //            principal_id = c.Int(nullable: false),
            //            version = c.Int(),
            //            definition = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.diagram_id);
            
            //CreateTable(
            //    "dbo.Log",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Date = c.DateTime(nullable: false),
            //            Thread = c.String(nullable: false, maxLength: 255),
            //            Level = c.String(nullable: false, maxLength: 50),
            //            Logger = c.String(nullable: false, maxLength: 255),
            //            Message = c.String(nullable: false, maxLength: 4000),
            //            Exception = c.String(maxLength: 2000),
            //        })
            //    .PrimaryKey(t => new { t.Id, t.Date, t.Thread, t.Level, t.Logger, t.Message });
            
            //CreateTable(
            //    "dbo.Tickets",
            //    c => new
            //        {
            //            id = c.Int(nullable: false, identity: true),
            //            TicketNumber = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.id);
            
            //CreateTable(
            //    "dbo.Template_Fields_grpOptions",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            FieldId = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 50),
            //            Label = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Template_Fields",
            //    c => new
            //        {
            //            FieldId = c.Int(nullable: false, identity: true),
            //            TemplateId = c.Int(nullable: false),
            //            Name = c.String(nullable: false),
            //            Label = c.String(),
            //            FieldType = c.Int(nullable: false),
            //            ToBeFilled = c.Boolean(),
            //            IsActive = c.Boolean(),
            //        })
            //    .PrimaryKey(t => t.FieldId);
            
            //CreateTable(
            //    "dbo.Forms_Data",
            //    c => new
            //        {
            //            FieldId = c.Int(nullable: false),
            //            FormId = c.Int(nullable: false),
            //            Value = c.String(nullable: false),
            //            CreatedDate = c.DateTime(),
            //            CreatedBy = c.String(maxLength: 50),
            //            ModifiedDate = c.DateTime(),
            //            ModifiedBy = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => new { t.FieldId, t.FormId });
            
            //CreateTable(
            //    "dbo.Forms",
            //    c => new
            //        {
            //            FormId = c.Int(nullable: false, identity: true),
            //            TemplateId = c.Int(nullable: false),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            Path = c.String(maxLength: 150),
            //            Status = c.Int(),
            //            CreatedDate = c.DateTime(),
            //            CreatedBy = c.String(maxLength: 50),
            //            ModifiedDate = c.DateTime(),
            //            ModifiedBy = c.String(maxLength: 50),
            //            Ticket = c.Int(),
            //        })
            //    .PrimaryKey(t => t.FormId);
            
            //CreateTable(
            //    "dbo.Documents",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Data = c.Binary(),
            //            TemplateId = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Templates",
            //    c => new
            //        {
            //            TemplateId = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 100),
            //            Path = c.String(nullable: false, maxLength: 150),
            //            Category = c.Int(nullable: false),
            //            Type = c.Int(nullable: false),
            //            Status = c.Int(nullable: false),
            //            AddedDate = c.DateTime(),
            //            AddedBy = c.String(maxLength: 50),
            //            ModifiedDate = c.DateTime(),
            //            ModifiedBy = c.String(maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.TemplateId);
            
            //CreateTable(
            //    "dbo.Applications",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(nullable: false, maxLength: 50),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Application_Template",
            //    c => new
            //        {
            //            ApplicationId = c.Int(nullable: false),
            //            TemplateId = c.Int(nullable: false),
            //            IsRequired = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => new { t.ApplicationId, t.TemplateId });
            
            //DropTable("dbo.view_opened_leads");
            //CreateIndex("dbo.Tokens", "UserId");
            //CreateIndex("dbo.Template_Fields_grpOptions", "FieldId");
            //CreateIndex("dbo.Template_Fields", "TemplateId");
            //CreateIndex("dbo.Forms_Data", "FieldId");
            //CreateIndex("dbo.Forms_Data", "FormId");
            //CreateIndex("dbo.Forms", "TemplateId");
            //CreateIndex("dbo.Forms", "Ticket");
            //CreateIndex("dbo.Documents", "TemplateId");
            //CreateIndex("dbo.Application_Template", "TemplateId");
            //CreateIndex("dbo.Application_Template", "ApplicationId");
            //AddForeignKey("dbo.Tokens", "UserId", "dbo.Users", "id", cascadeDelete: true);
            //AddForeignKey("dbo.Template_Fields_grpOptions", "FieldId", "dbo.Template_Fields", "FieldId", cascadeDelete: true);
            //AddForeignKey("dbo.Template_Fields", "TemplateId", "dbo.Templates", "TemplateId", cascadeDelete: true);
            //AddForeignKey("dbo.Forms_Data", "FieldId", "dbo.Template_Fields", "FieldId", cascadeDelete: true);
            //AddForeignKey("dbo.Forms_Data", "FormId", "dbo.Forms", "FormId", cascadeDelete: true);
            //AddForeignKey("dbo.Forms", "TemplateId", "dbo.Templates", "TemplateId", cascadeDelete: true);
            //AddForeignKey("dbo.Forms", "Ticket", "dbo.Tickets", "id");
            //AddForeignKey("dbo.Documents", "TemplateId", "dbo.Templates", "TemplateId", cascadeDelete: true);
            //AddForeignKey("dbo.Application_Template", "TemplateId", "dbo.Templates", "TemplateId", cascadeDelete: true);
            //AddForeignKey("dbo.Application_Template", "ApplicationId", "dbo.Applications", "Id", cascadeDelete: true);
        }
    }
}
