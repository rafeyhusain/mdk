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
                        CarId = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Price = c.Int(nullable: false),
                        PriceOriginal = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Make = c.Int(nullable: false),
                        Model = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Condition = c.Int(nullable: false),
                        ExteriorColor = c.Int(nullable: false),
                        InteriorColor = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        Engine = c.Int(nullable: false),
                        DriveTrain = c.Int(nullable: false),
                        Location = c.Int(nullable: false),
                        StockId = c.String(),
                        ChassisNo = c.String(),
                        Displacement = c.Int(nullable: false),
                        Steering = c.Int(nullable: false),
                        FuelType = c.Int(nullable: false),
                        Door = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Featured = c.Boolean(nullable: false),
                        Image = c.String(),
                        Summary = c.String(),
                        Images = c.String(storeType: "ntext"),
                        GeneralInformation = c.String(storeType: "ntext"),
                        VechileOverview = c.String(storeType: "ntext"),
                        Options = c.String(storeType: "ntext"),
                        Features = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.CarId)
                .Index(t => t.Price)
                .Index(t => t.Rating)
                .Index(t => t.Make)
                .Index(t => t.Model)
                .Index(t => t.Year)
                .Index(t => t.Mileage)
                .Index(t => t.Condition)
                .Index(t => t.ExteriorColor)
                .Index(t => t.InteriorColor)
                .Index(t => t.Transmission)
                .Index(t => t.Engine)
                .Index(t => t.DriveTrain)
                .Index(t => t.Location)
                .Index(t => t.Displacement)
                .Index(t => t.Steering)
                .Index(t => t.FuelType)
                .Index(t => t.Door)
                .Index(t => t.Grade)
                .Index(t => t.Featured);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cars", new[] { "Featured" });
            DropIndex("dbo.Cars", new[] { "Grade" });
            DropIndex("dbo.Cars", new[] { "Door" });
            DropIndex("dbo.Cars", new[] { "FuelType" });
            DropIndex("dbo.Cars", new[] { "Steering" });
            DropIndex("dbo.Cars", new[] { "Displacement" });
            DropIndex("dbo.Cars", new[] { "Location" });
            DropIndex("dbo.Cars", new[] { "DriveTrain" });
            DropIndex("dbo.Cars", new[] { "Engine" });
            DropIndex("dbo.Cars", new[] { "Transmission" });
            DropIndex("dbo.Cars", new[] { "InteriorColor" });
            DropIndex("dbo.Cars", new[] { "ExteriorColor" });
            DropIndex("dbo.Cars", new[] { "Condition" });
            DropIndex("dbo.Cars", new[] { "Mileage" });
            DropIndex("dbo.Cars", new[] { "Year" });
            DropIndex("dbo.Cars", new[] { "Model" });
            DropIndex("dbo.Cars", new[] { "Make" });
            DropIndex("dbo.Cars", new[] { "Rating" });
            DropIndex("dbo.Cars", new[] { "Price" });
            DropTable("dbo.Cars");
        }
    }
}
