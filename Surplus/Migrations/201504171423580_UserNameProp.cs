namespace Surplus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurplusRequest", "UserName", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SurplusRequest", "UserName");
        }
    }
}
