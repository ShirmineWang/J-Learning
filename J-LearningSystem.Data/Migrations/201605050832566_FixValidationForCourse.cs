namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixValidationForCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.Courses", new[] { "Staff_Id" });
            DropIndex("dbo.Courses", new[] { "Schedule_Id" });
            AlterColumn("dbo.Courses", "Staff_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "Schedule_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "Schedule_Id");
            CreateIndex("dbo.Courses", "Staff_Id");
            AddForeignKey("dbo.Courses", "Schedule_Id", "dbo.Schedules", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Schedule_Id", "dbo.Schedules");
            DropIndex("dbo.Courses", new[] { "Staff_Id" });
            DropIndex("dbo.Courses", new[] { "Schedule_Id" });
            AlterColumn("dbo.Courses", "Schedule_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "Staff_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "Schedule_Id");
            CreateIndex("dbo.Courses", "Staff_Id");
            AddForeignKey("dbo.Courses", "Schedule_Id", "dbo.Schedules", "Id");
        }
    }
}
