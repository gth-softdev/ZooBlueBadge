namespace ZooBlue.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttractionMigrationFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attraction", "SeasonalAttractions", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attraction", "SeasonalAttractions");
        }
    }
}
