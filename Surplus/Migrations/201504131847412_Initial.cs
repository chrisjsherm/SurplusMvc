namespace Surplus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixedAsset",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AssetNumber = c.String(nullable: false, maxLength: 9),
                        TitleCode = c.String(maxLength: 10),
                        TitleDescription = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemCondition",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.QuantityDescription",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SurplusRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VTBarcode = c.String(nullable: false, maxLength: 9),
                        Description = c.String(nullable: false, maxLength: 50),
                        Manufacturer = c.String(maxLength: 35),
                        Model = c.String(maxLength: 30),
                        SerialNumber = c.String(maxLength: 40),
                        Quantity = c.Int(nullable: false),
                        QuantityDescriptionId = c.Guid(nullable: false),
                        EstimatedValue = c.Int(),
                        ItemConditionId = c.Guid(nullable: false),
                        DepartmentNumber = c.String(nullable: false, maxLength: 6),
                        DepartmentDescription = c.String(maxLength: 200),
                        Building = c.String(nullable: false),
                        FloorLevel = c.String(nullable: false),
                        ContactName = c.String(nullable: false),
                        ContactPhone = c.String(nullable: false, maxLength: 10),
                        AuthorizerName = c.String(nullable: false),
                        AdditionalDetails = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ItemCondition", t => t.ItemConditionId, cascadeDelete: true)
                .ForeignKey("dbo.QuantityDescription", t => t.QuantityDescriptionId, cascadeDelete: true)
                .Index(t => t.QuantityDescriptionId)
                .Index(t => t.ItemConditionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SurplusRequest", "QuantityDescriptionId", "dbo.QuantityDescription");
            DropForeignKey("dbo.SurplusRequest", "ItemConditionId", "dbo.ItemCondition");
            DropIndex("dbo.SurplusRequest", new[] { "ItemConditionId" });
            DropIndex("dbo.SurplusRequest", new[] { "QuantityDescriptionId" });
            DropTable("dbo.SurplusRequest");
            DropTable("dbo.QuantityDescription");
            DropTable("dbo.ItemCondition");
            DropTable("dbo.FixedAsset");
        }
    }
}
