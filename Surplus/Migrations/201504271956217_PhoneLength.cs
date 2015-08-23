namespace Surplus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SurplusRequest", "ContactPhone", c => c.String(nullable: false, maxLength: 14));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurplusRequest", "ContactPhone", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
