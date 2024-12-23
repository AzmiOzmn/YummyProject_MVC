namespace YummyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateeventdecimaltoint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
