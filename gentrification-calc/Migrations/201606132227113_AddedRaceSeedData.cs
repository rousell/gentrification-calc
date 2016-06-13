namespace gentrification_calc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRaceSeedData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PopulationYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PopYear = c.Int(nullable: false),
                        DemographicId = c.Int(nullable: false),
                        PopulationByRace = c.Int(nullable: false),
                        Zip_ZipCodeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Demographics", t => t.DemographicId, cascadeDelete: true)
                .ForeignKey("dbo.ZipCodes", t => t.Zip_ZipCodeId)
                .Index(t => t.DemographicId)
                .Index(t => t.Zip_ZipCodeId);
            
            DropColumn("dbo.Demographics", "DemographicYear");
            DropColumn("dbo.Demographics", "Population");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Demographics", "Population", c => c.Int(nullable: false));
            AddColumn("dbo.Demographics", "DemographicYear", c => c.Int(nullable: false));
            DropForeignKey("dbo.PopulationYears", "Zip_ZipCodeId", "dbo.ZipCodes");
            DropForeignKey("dbo.PopulationYears", "DemographicId", "dbo.Demographics");
            DropIndex("dbo.PopulationYears", new[] { "Zip_ZipCodeId" });
            DropIndex("dbo.PopulationYears", new[] { "DemographicId" });
            DropTable("dbo.PopulationYears");
        }
    }
}
