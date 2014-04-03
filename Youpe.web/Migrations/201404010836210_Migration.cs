namespace Youpe.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogComment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        PostId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.Post", t => t.PostId)
                .Index(t => t.PostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        Visibility = c.Int(),
                        ThemeId = c.Long(),
                        BlogId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .ForeignKey("dbo.Theme", t => t.ThemeId)
                .Index(t => t.ThemeId)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Blog",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        IsActive = c.Boolean(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Mobile = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        Zip = c.String(),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        GuidFacebook = c.String(),
                        IsActive = c.Boolean(),
                        Birthday = c.DateTime(),
                        Address = c.String(),
                        RankId = c.Long(),
                        RoleId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rank", t => t.RankId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .Index(t => t.RankId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Color = c.String(),
                        EventId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Slots = c.Int(nullable: false),
                        Cost = c.Double(),
                        Public = c.Boolean(),
                        Description = c.String(),
                        ThemeId = c.Long(),
                        Address = c.String(),
                        Lattitude = c.Single(),
                        Longitude = c.Single(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                        UserProfile_Id = c.Long(),
                        UserProfile_Id1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theme", t => t.ThemeId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_Id1)
                .Index(t => t.ThemeId)
                .Index(t => t.UserId)
                .Index(t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id1);
            
            CreateTable(
                "dbo.EventComment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Content = c.String(),
                        EventId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Rate = c.Int(),
                        Comment = c.String(),
                        EventId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.EventId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Theme",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ThemeId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Theme", t => t.ThemeId)
                .Index(t => t.ThemeId);
            
            CreateTable(
                "dbo.Thread",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        IsSharable = c.Boolean(),
                        ThemeId = c.Long(),
                        EventId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Event", t => t.EventId)
                .ForeignKey("dbo.Theme", t => t.ThemeId)
                .Index(t => t.ThemeId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ThreadId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.ThreadId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ThreadId = c.Long(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thread", t => t.ThreadId)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.ThreadId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Url = c.String(),
                        UserId = c.Long(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Rank",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LevelRank = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Label = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                        CreatedIp = c.String(),
                        UpdatedIp = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThemeUserProfile",
                c => new
                    {
                        Theme_Id = c.Long(nullable: false),
                        UserProfile_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Theme_Id, t.UserProfile_Id })
                .ForeignKey("dbo.Theme", t => t.Theme_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_Id, cascadeDelete: true)
                .Index(t => t.Theme_Id)
                .Index(t => t.UserProfile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogComment", "PostId", "dbo.Post");
            DropForeignKey("dbo.UserProfile", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserProfile", "RankId", "dbo.Rank");
            DropForeignKey("dbo.Photo", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Event", "UserProfile_Id1", "dbo.UserProfile");
            DropForeignKey("dbo.Event", "UserProfile_Id", "dbo.UserProfile");
            DropForeignKey("dbo.Card", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Event", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.ThemeUserProfile", "UserProfile_Id", "dbo.UserProfile");
            DropForeignKey("dbo.ThemeUserProfile", "Theme_Id", "dbo.Theme");
            DropForeignKey("dbo.Thread", "ThemeId", "dbo.Theme");
            DropForeignKey("dbo.Message", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Message", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Favorite", "ThreadId", "dbo.Thread");
            DropForeignKey("dbo.Thread", "EventId", "dbo.Event");
            DropForeignKey("dbo.Theme", "ThemeId", "dbo.Theme");
            DropForeignKey("dbo.Post", "ThemeId", "dbo.Theme");
            DropForeignKey("dbo.Event", "ThemeId", "dbo.Theme");
            DropForeignKey("dbo.Rating", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Rating", "EventId", "dbo.Event");
            DropForeignKey("dbo.EventComment", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.EventComment", "EventId", "dbo.Event");
            DropForeignKey("dbo.Card", "EventId", "dbo.Event");
            DropForeignKey("dbo.Blog", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.BlogComment", "UserId", "dbo.UserProfile");
            DropForeignKey("dbo.Post", "BlogId", "dbo.Blog");
            DropIndex("dbo.ThemeUserProfile", new[] { "UserProfile_Id" });
            DropIndex("dbo.ThemeUserProfile", new[] { "Theme_Id" });
            DropIndex("dbo.Photo", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "UserId" });
            DropIndex("dbo.Message", new[] { "ThreadId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "ThreadId" });
            DropIndex("dbo.Thread", new[] { "EventId" });
            DropIndex("dbo.Thread", new[] { "ThemeId" });
            DropIndex("dbo.Theme", new[] { "ThemeId" });
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropIndex("dbo.Rating", new[] { "EventId" });
            DropIndex("dbo.EventComment", new[] { "UserId" });
            DropIndex("dbo.EventComment", new[] { "EventId" });
            DropIndex("dbo.Event", new[] { "UserProfile_Id1" });
            DropIndex("dbo.Event", new[] { "UserProfile_Id" });
            DropIndex("dbo.Event", new[] { "UserId" });
            DropIndex("dbo.Event", new[] { "ThemeId" });
            DropIndex("dbo.Card", new[] { "UserId" });
            DropIndex("dbo.Card", new[] { "EventId" });
            DropIndex("dbo.UserProfile", new[] { "RoleId" });
            DropIndex("dbo.UserProfile", new[] { "RankId" });
            DropIndex("dbo.Blog", new[] { "UserId" });
            DropIndex("dbo.Post", new[] { "BlogId" });
            DropIndex("dbo.Post", new[] { "ThemeId" });
            DropIndex("dbo.BlogComment", new[] { "UserId" });
            DropIndex("dbo.BlogComment", new[] { "PostId" });
            DropTable("dbo.ThemeUserProfile");
            DropTable("dbo.Role");
            DropTable("dbo.Rank");
            DropTable("dbo.Photo");
            DropTable("dbo.Message");
            DropTable("dbo.Favorite");
            DropTable("dbo.Thread");
            DropTable("dbo.Theme");
            DropTable("dbo.Rating");
            DropTable("dbo.EventComment");
            DropTable("dbo.Event");
            DropTable("dbo.Card");
            DropTable("dbo.UserProfile");
            DropTable("dbo.Blog");
            DropTable("dbo.Post");
            DropTable("dbo.BlogComment");
        }
    }
}
