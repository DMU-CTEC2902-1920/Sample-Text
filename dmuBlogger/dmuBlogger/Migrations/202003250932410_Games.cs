namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Games : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameGenre", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Genre = c.String(),
                        Description = c.String(nullable: false),
                        Score = c.Int(nullable: false),
                        SelectedDeveloper = c.String(),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID);
            
            DropTable("dbo.Games");
        }
    }
}
