namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blacklist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blacklists", "BlacklistIP", c => c.String(nullable: false));
            DropColumn("dbo.Blacklists", "BlacklistEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blacklists", "BlacklistEmail", c => c.String(nullable: false));
            DropColumn("dbo.Blacklists", "BlacklistIP");
        }
    }
}
