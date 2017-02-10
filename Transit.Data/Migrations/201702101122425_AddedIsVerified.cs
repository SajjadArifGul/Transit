namespace Transit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsVerified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "IsVerified", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicles", "IsVerified", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsVerified");
            DropColumn("dbo.Routes", "IsVerified");
        }
    }
}
