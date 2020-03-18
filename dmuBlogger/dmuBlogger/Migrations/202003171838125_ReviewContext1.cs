namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewContext1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Developer_DeveloperId", "dbo.Developers");
            DropIndex("dbo.Reviews", new[] { "Developer_DeveloperId" });
            DropColumn("dbo.Reviews", "Developer_DeveloperId");
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
                    })
                .PrimaryKey(t => t.DeveloperId);
            
            AddColumn("dbo.Reviews", "Developer_DeveloperId", c => c.Int());
            CreateIndex("dbo.Reviews", "Developer_DeveloperId");
            AddForeignKey("dbo.Reviews", "Developer_DeveloperId", "dbo.Developers", "DeveloperId");
        }
    }
}
