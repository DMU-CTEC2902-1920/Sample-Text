namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        GameId = c.Int(nullable: false, identity: true),
                        DeveloperID = c.Int(nullable: false),
                        GameName = c.String(nullable: false),
                        GameReleaseDate = c.String(),
                    })
                .PrimaryKey(t => t.GameId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Game_GameId = c.Int(),
                    })
                .PrimaryKey(t => t.DeveloperId)
                .ForeignKey("dbo.Games", t => t.Game_GameId)
                .Index(t => t.Game_GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Developers", "Game_GameId", "dbo.Games");
            DropIndex("dbo.Developers", new[] { "Game_GameId" });
            DropTable("dbo.Developers");
            DropTable("dbo.Games");
        }
    }
}
