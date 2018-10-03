namespace StarWarsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Persoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirdthDate = c.DateTime(),
                        Mass = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Perso_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Persoes", t => t.Perso_ID)
                .Index(t => t.Perso_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Episodes", "Perso_ID", "dbo.Persoes");
            DropIndex("dbo.Episodes", new[] { "Perso_ID" });
            DropTable("dbo.Episodes");
            DropTable("dbo.Persoes");
        }
    }
}
