namespace ForumTest2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FORUM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Pass = c.String(),
                        Active = c.Int(nullable: false),
                        Profile = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Topic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Creator = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.Creator, cascadeDelete: true)
                .Index(t => t.Creator);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Topic", "Creator", "dbo.ApplicationUser");
            DropIndex("dbo.Topic", new[] { "Creator" });
            DropTable("dbo.Topic");
            DropTable("dbo.ApplicationUser");
        }
    }
}
