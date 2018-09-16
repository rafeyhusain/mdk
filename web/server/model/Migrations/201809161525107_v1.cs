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
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        Condition = c.String(),
                        ExteriorColor = c.String(),
                        InteriorColor = c.String(),
                        Transmission = c.String(),
                        Engine = c.String(),
                        DriveTrain = c.String(),
                        Location = c.String(),
                        StockId = c.String(),
                        ChassisNo = c.String(),
                        Displacement = c.Int(nullable: false),
                        Steering = c.String(),
                        FuelType = c.String(),
                        Door = c.String(),
                        Grade = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.CarId)
                .Index(t => t.Price)
                .Index(t => t.Year)
                .Index(t => t.Mileage);
            
            CreateTable(
                "dbo.CarDetails",
                c => new
                    {
                        CarDetailId = c.Int(nullable: false, identity: true),
                        Images = c.String(storeType: "ntext"),
                        GeneralInformation = c.String(storeType: "ntext"),
                        VechileOverview = c.String(storeType: "ntext"),
                        Options = c.String(storeType: "ntext"),
                        Features = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.CarDetailId)
                .ForeignKey("dbo.Cars", t => t.CarDetailId)
                .Index(t => t.CarDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarDetails", "CarDetailId", "dbo.Cars");
            DropIndex("dbo.CarDetails", new[] { "CarDetailId" });
            DropIndex("dbo.Cars", new[] { "Mileage" });
            DropIndex("dbo.Cars", new[] { "Year" });
            DropIndex("dbo.Cars", new[] { "Price" });
            DropTable("dbo.CarDetails");
            DropTable("dbo.Cars");
        }
    }
}
