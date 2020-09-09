namespace ZooBlue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attraction",
                c => new
                    {
                        AttId = c.Int(nullable: false, identity: true),
                        HasAquaticExhibit = c.Boolean(nullable: false),
                        HasGarden = c.Boolean(nullable: false),
                        ZooId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttId)
                .ForeignKey("dbo.Zoo", t => t.ZooId, cascadeDelete: true)
                .Index(t => t.ZooId);
            
            CreateTable(
                "dbo.Zoo",
                c => new
                    {
                        ZooId = c.Int(nullable: false, identity: true),
                        ZooName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ZooSize = c.Double(nullable: false),
                        AZAAccredited = c.Boolean(nullable: false),
                        Admission = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ZooId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        ReviewText = c.String(),
                        VisitDate = c.DateTime(nullable: false),
                        ZooId = c.Int(nullable: false),
                        Author = c.Guid(nullable: false),
                        IsRecommended = c.Boolean(nullable: false),
                        Zoo_ZooId = c.Int(),
                        Zoo_ZooId1 = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Zoo", t => t.ZooId, cascadeDelete: true)
                .ForeignKey("dbo.Zoo", t => t.Zoo_ZooId)
                .ForeignKey("dbo.Zoo", t => t.Zoo_ZooId1)
                .Index(t => t.ZooId)
                .Index(t => t.Zoo_ZooId)
                .Index(t => t.Zoo_ZooId1);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Attraction", "ZooId", "dbo.Zoo");
            DropForeignKey("dbo.Review", "Zoo_ZooId1", "dbo.Zoo");
            DropForeignKey("dbo.Review", "Zoo_ZooId", "dbo.Zoo");
            DropForeignKey("dbo.Review", "ZooId", "dbo.Zoo");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Review", new[] { "Zoo_ZooId1" });
            DropIndex("dbo.Review", new[] { "Zoo_ZooId" });
            DropIndex("dbo.Review", new[] { "ZooId" });
            DropIndex("dbo.Attraction", new[] { "ZooId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Review");
            DropTable("dbo.Zoo");
            DropTable("dbo.Attraction");
        }
    }
}
