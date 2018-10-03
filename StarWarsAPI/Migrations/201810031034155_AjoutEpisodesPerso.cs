namespace StarWarsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutEpisodesPerso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "Perso_ID", c => c.Int());
            CreateIndex("dbo.Episodes", "Perso_ID");
            AddForeignKey("dbo.Episodes", "Perso_ID", "dbo.Persoes", "ID");
            DropColumn("dbo.Persoes", "Episodes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persoes", "Episodes", c => c.String());
            DropForeignKey("dbo.Episodes", "Perso_ID", "dbo.Persoes");
            DropIndex("dbo.Episodes", new[] { "Perso_ID" });
            DropColumn("dbo.Episodes", "Perso_ID");
        }
    }
}
