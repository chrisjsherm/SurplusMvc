namespace Surplus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredDeptDesc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SurplusRequest", "DepartmentDescription", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurplusRequest", "DepartmentDescription", c => c.String(maxLength: 200));
        }
    }
}
