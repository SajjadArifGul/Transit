namespace Transit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameInTransitURL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransitURLs", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransitURLs", "Name");
        }
    }
}
