namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blacklist1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blacklists", "BlacklistReason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blacklists", "BlacklistReason");
        }
    }
}
