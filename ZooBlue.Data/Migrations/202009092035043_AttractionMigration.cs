namespace ZooBlue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttractionMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attraction", "Animals", c => c.String(nullable: false));
            AddColumn("dbo.Attraction", "Experiences", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attraction", "Experiences");
            DropColumn("dbo.Attraction", "Animals");
        }
    }
}
