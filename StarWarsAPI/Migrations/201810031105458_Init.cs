namespace StarWarsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
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
            
            AddColumn("dbo.Persoes", "Episode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Persoes", "Episode");
            DropTable("dbo.Episodes");
        }
    }
}
