namespace Transit.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransitURL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransitURLs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransitURLs");
        }
    }
}
