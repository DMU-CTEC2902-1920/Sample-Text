namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reviews1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DeveloperID", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "DeveloperID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "DeveloperID", c => c.String());
            DropColumn("dbo.Reviews", "DeveloperID");
        }
    }
}
