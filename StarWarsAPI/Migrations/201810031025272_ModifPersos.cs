namespace StarWarsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifPersos : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Episodes", "Perso_ID", "dbo.Persoes");
            DropIndex("dbo.Episodes", new[] { "Perso_ID" });
            AddColumn("dbo.Persoes", "Episodes", c => c.String());
            AlterColumn("dbo.Persoes", "BirdthDate", c => c.String());
            DropTable("dbo.Episodes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Perso_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.Persoes", "BirdthDate", c => c.DateTime());
            DropColumn("dbo.Persoes", "Episodes");
            CreateIndex("dbo.Episodes", "Perso_ID");
            AddForeignKey("dbo.Episodes", "Perso_ID", "dbo.Persoes", "ID");
        }
    }
}
