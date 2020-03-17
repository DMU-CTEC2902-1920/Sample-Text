namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewContext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Score", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "Score");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Score", c => c.String());
            DropColumn("dbo.Reviews", "Score");
        }
    }
}
