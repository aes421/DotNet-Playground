namespace LearningDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addanassocationbetweenthetaskandtheuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.UserTasks", "UserId");
            AddForeignKey("dbo.UserTasks", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserTasks", new[] { "UserId" });
            DropColumn("dbo.UserTasks", "UserId");
        }
    }
}
