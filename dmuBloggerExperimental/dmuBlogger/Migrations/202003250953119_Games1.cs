namespace dmuBlogger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Games1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "GameGenre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "GameGenre", c => c.Int(nullable: false));
        }
    }
}
