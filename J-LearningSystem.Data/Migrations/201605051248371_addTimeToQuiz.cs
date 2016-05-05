namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimeToQuiz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "TimeCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "TimeCreated");
        }
    }
}
