namespace LearningDotNet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Status ON");
            Sql("INSERT INTO Status (Id, Description) VALUES (1, 'To-Do')");
            Sql("INSERT INTO Status (Id, Description) VALUES (2, 'In Progress')");
            Sql("INSERT INTO Status (Id, Description) VALUES (3, 'Complete')");
            Sql("SET IDENTITY_INSERT Status OFF");
    }
        
        public override void Down()
        {
            Sql("DELETE FROM Status WHERE Id IN (1,2,3)");
        }
    }
}
