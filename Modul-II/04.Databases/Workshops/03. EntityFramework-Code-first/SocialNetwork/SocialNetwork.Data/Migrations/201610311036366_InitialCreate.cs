namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Approved = c.Boolean(nullable: false),
                        FriendShipSince = c.DateTime(nullable: false),
                        FirstUserId = c.Int(nullable: false),
                        SecondUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FirstUserId)
                .ForeignKey("dbo.Users", t => t.SecondUserId)
                .Index(t => t.Approved)
                .Index(t => t.FirstUserId)
                .Index(t => t.SecondUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        RegisteredOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        FileExtension = c.String(nullable: false, maxLength: 4),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AuthorId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        SeenOn = c.DateTime(),
                        FriendshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .ForeignKey("dbo.Friendships", t => t.FriendshipId)
                .Index(t => t.AuthorId)
                .Index(t => t.SentOn)
                .Index(t => t.FriendshipId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostedOn = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostUsers",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.User_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "SecondUserId", "dbo.Users");
            DropForeignKey("dbo.Friendships", "FirstUserId", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Messages", "FriendshipId", "dbo.Friendships");
            DropForeignKey("dbo.Messages", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropIndex("dbo.PostUsers", new[] { "User_Id" });
            DropIndex("dbo.PostUsers", new[] { "Post_Id" });
            DropIndex("dbo.Messages", new[] { "FriendshipId" });
            DropIndex("dbo.Messages", new[] { "SentOn" });
            DropIndex("dbo.Messages", new[] { "AuthorId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Friendships", new[] { "SecondUserId" });
            DropIndex("dbo.Friendships", new[] { "FirstUserId" });
            DropIndex("dbo.Friendships", new[] { "Approved" });
            DropTable("dbo.PostUsers");
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Friendships");
        }
    }
}
