namespace StarWarsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutEpisodes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Episodes");
        }
    }
}
