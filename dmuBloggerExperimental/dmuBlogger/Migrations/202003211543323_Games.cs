namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Games : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Developers", "Game_GameId", "dbo.Games");
            DropIndex("dbo.Developers", new[] { "Game_GameId" });
            DropTable("dbo.Developers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Game_GameId = c.Int(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            CreateIndex("dbo.Developers", "Game_GameId");
            AddForeignKey("dbo.Developers", "Game_GameId", "dbo.Games", "GameId");
        }
    }
}
