namespace LearningDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatusIdFieldName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserTasks", "Status_StatusId", "dbo.Status");
            RenameColumn(table: "dbo.UserTasks", name: "Status_StatusId", newName: "Status_Id");
            RenameIndex(table: "dbo.UserTasks", name: "IX_Status_StatusId", newName: "IX_Status_Id");
            DropPrimaryKey("dbo.Status");
            DropColumn("dbo.Status", "StatusId");
            AddColumn("dbo.Status", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Status", "Id");
            AddForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "Status_Id", "dbo.Status");
            DropPrimaryKey("dbo.Status");
            DropColumn("dbo.Status", "Id");
            AddColumn("dbo.Status", "StatusId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Status", "StatusId");
            RenameIndex(table: "dbo.UserTasks", name: "IX_Status_Id", newName: "IX_Status_StatusId");
            RenameColumn(table: "dbo.UserTasks", name: "Status_Id", newName: "Status_StatusId");
            AddForeignKey("dbo.UserTasks", "Status_StatusId", "dbo.Status", "StatusId");
        }
    }
}
