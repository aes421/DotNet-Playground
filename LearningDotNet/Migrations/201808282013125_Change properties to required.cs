namespace LearningDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changepropertiestorequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status");
            DropIndex("dbo.UserTasks", new[] { "Status_Id" });
            AlterColumn("dbo.UserTasks", "TaskName", c => c.String(nullable: false));
            AlterColumn("dbo.UserTasks", "Status_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Status", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.UserTasks", "Status_Id");
            AddForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status");
            DropIndex("dbo.UserTasks", new[] { "Status_Id" });
            AlterColumn("dbo.Status", "Description", c => c.String());
            AlterColumn("dbo.UserTasks", "Status_Id", c => c.Int());
            AlterColumn("dbo.UserTasks", "TaskName", c => c.String());
            CreateIndex("dbo.UserTasks", "Status_Id");
            AddForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status", "Id");
        }
    }
}
