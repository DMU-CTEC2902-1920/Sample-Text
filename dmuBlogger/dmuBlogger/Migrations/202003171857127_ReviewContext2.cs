namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewContext2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "SelectedDeveloper", c => c.String());
            AddColumn("dbo.Reviews", "SelectedGame", c => c.String());
            AlterColumn("dbo.Reviews", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Reviews", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "Description", c => c.String());
            AlterColumn("dbo.Reviews", "Title", c => c.String());
            DropColumn("dbo.Reviews", "SelectedGame");
            DropColumn("dbo.Reviews", "SelectedDeveloper");
        }
    }
}
