namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "GameID", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "GameID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "GameID", c => c.String());
            DropColumn("dbo.Reviews", "GameID");
        }
    }
}
