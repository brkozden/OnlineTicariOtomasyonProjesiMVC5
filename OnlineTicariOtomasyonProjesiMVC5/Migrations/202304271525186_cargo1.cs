namespace OnlineTicariOtomasyonProjesiMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargo1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        cargoId = c.Int(nullable: false, identity: true),
                        explanation = c.String(maxLength: 300, unicode: false),
                        trackingCode = c.String(maxLength: 10, unicode: false),
                        seller = c.String(maxLength: 30, unicode: false),
                        buyer = c.String(maxLength: 30, unicode: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cargoId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        cargoTrackingId = c.Int(nullable: false, identity: true),
                        trackingCode = c.String(maxLength: 10, unicode: false),
                        explanation = c.String(maxLength: 100, unicode: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cargoTrackingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
