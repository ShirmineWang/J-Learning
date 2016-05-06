namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMigrationaddQuizTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "Title");
        }
    }
}
