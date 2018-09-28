namespace model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Price = c.Int(nullable: false),
                        PriceOriginal = c.Int(nullable: false),
                        Make = c.Int(nullable: false),
                        Model = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        Location = c.Int(nullable: false),
                        StockId = c.String(),
                        ChassisNo = c.String(),
                        Displacement = c.Int(nullable: false),
                        Steering = c.Int(nullable: false),
                        FuelType = c.Int(nullable: false),
                        Door = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Featured = c.Boolean(nullable: false),
                        Features = c.String(storeType: "ntext"),
                        Images = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Price)
                .Index(t => t.Make)
                .Index(t => t.Model)
                .Index(t => t.Year)
                .Index(t => t.Mileage)
                .Index(t => t.Color)
                .Index(t => t.Transmission)
                .Index(t => t.Location)
                .Index(t => t.Displacement)
                .Index(t => t.FuelType)
                .Index(t => t.Door)
                .Index(t => t.Grade)
                .Index(t => t.Featured);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Make_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Makes", t => t.Make_Id, cascadeDelete: true)
                .Index(t => t.Make_Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Models", "Make_Id", "dbo.Makes");
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.Models", new[] { "Make_Id" });
            DropIndex("dbo.Cars", new[] { "Featured" });
            DropIndex("dbo.Cars", new[] { "Grade" });
            DropIndex("dbo.Cars", new[] { "Door" });
            DropIndex("dbo.Cars", new[] { "FuelType" });
            DropIndex("dbo.Cars", new[] { "Displacement" });
            DropIndex("dbo.Cars", new[] { "Location" });
            DropIndex("dbo.Cars", new[] { "Transmission" });
            DropIndex("dbo.Cars", new[] { "Color" });
            DropIndex("dbo.Cars", new[] { "Mileage" });
            DropIndex("dbo.Cars", new[] { "Year" });
            DropIndex("dbo.Cars", new[] { "Model" });
            DropIndex("dbo.Cars", new[] { "Make" });
            DropIndex("dbo.Cars", new[] { "Price" });
            DropTable("dbo.UserLogin");
            DropTable("dbo.UserClaim");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
            DropTable("dbo.Grades");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.Doors");
            DropTable("dbo.Countries");
            DropTable("dbo.Colors");
            DropTable("dbo.Cars");
        }
    }
}
