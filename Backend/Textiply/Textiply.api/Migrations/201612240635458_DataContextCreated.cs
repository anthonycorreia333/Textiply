namespace Textiply.Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataContextCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audiences",
                c => new
                    {
                        AudienceId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Gender = c.Int(),
                    })
                .PrimaryKey(t => t.AudienceId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        AudienceId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Sent = c.DateTime(nullable: false),
                        Text = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Audiences", t => t.AudienceId)
                .Index(t => t.AudienceId)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "BusinessName", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "AudienceId", "dbo.Audiences");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Audiences", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "AudienceId" });
            DropIndex("dbo.Audiences", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "BusinessName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Messages");
            DropTable("dbo.Audiences");
        }
    }
}
