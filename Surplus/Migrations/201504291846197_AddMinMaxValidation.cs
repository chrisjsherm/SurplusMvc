namespace Surplus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMinMaxValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SurplusRequest", "Building", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SurplusRequest", "FloorLevel", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SurplusRequest", "ContactName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SurplusRequest", "AuthorizerName", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.SurplusRequest", "AdditionalDetails", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurplusRequest", "AdditionalDetails", c => c.String(maxLength: 200));
            AlterColumn("dbo.SurplusRequest", "AuthorizerName", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "ContactName", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "FloorLevel", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "Building", c => c.String(nullable: false));
        }
    }
}
