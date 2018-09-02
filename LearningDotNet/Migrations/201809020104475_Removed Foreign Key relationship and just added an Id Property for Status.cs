namespace LearningDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedForeignKeyrelationshipandjustaddedanIdPropertyforStatus : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserTasks", name: "Status_Id", newName: "StatusId");
            RenameIndex(table: "dbo.UserTasks", name: "IX_Status_Id", newName: "IX_StatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserTasks", name: "IX_StatusId", newName: "IX_Status_Id");
            RenameColumn(table: "dbo.UserTasks", name: "StatusId", newName: "Status_Id");
        }
    }
}
