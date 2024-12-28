namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boolfalse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "IsApproved", c => c.Boolean());
        }
    }
}
