namespace ForumTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FORUMTEST2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topic", "Creator", "dbo.ApplicationUser");
            AddForeignKey("dbo.Topic", "Creator", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topic", "Creator", "dbo.ApplicationUser");
            AddForeignKey("dbo.Topic", "Creator", "dbo.ApplicationUser", "Id");
        }
    }
}
