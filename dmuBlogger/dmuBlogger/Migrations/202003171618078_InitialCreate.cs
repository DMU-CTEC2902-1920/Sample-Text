namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        Genre = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Score = c.String(),
                        Developer_DeveloperId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Developers", t => t.Developer_DeveloperId)
                .Index(t => t.Developer_DeveloperId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        DeveloperId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Developer_DeveloperId", "dbo.Developers");
            DropIndex("dbo.Reviews", new[] { "Developer_DeveloperId" });
            DropTable("dbo.Developers");
            DropTable("dbo.Reviews");
        }
    }
}
