namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteForum : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.QuestionOptionStudents", newName: "StudentQuestionOptions");
            DropForeignKey("dbo.Forums", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Topics", "Forum_Id", "dbo.Forums");
            DropForeignKey("dbo.Topics", "Person_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Forums", new[] { "Course_Id" });
            DropIndex("dbo.Topics", new[] { "Forum_Id" });
            DropIndex("dbo.Topics", new[] { "Person_Id" });
            DropPrimaryKey("dbo.StudentQuestionOptions");
            AddColumn("dbo.Topics", "Course_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Topics", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Topics", "Person_Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.StudentQuestionOptions", new[] { "Student_Id", "QuestionOption_Id" });
            CreateIndex("dbo.Topics", "Course_Id");
            CreateIndex("dbo.Topics", "Person_Id");
            AddForeignKey("dbo.Topics", "Course_Id", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Topics", "Person_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Topics", "Forum_Id");
            DropTable("dbo.Forums");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Forums",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OpenTime = c.DateTime(nullable: false),
                        ExpiryTime = c.DateTime(nullable: false),
                        Course_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Topics", "Forum_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Topics", "Person_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Topics", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Topics", new[] { "Person_Id" });
            DropIndex("dbo.Topics", new[] { "Course_Id" });
            DropPrimaryKey("dbo.StudentQuestionOptions");
            AlterColumn("dbo.Topics", "Person_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Topics", "Title", c => c.String());
            DropColumn("dbo.Topics", "Course_Id");
            AddPrimaryKey("dbo.StudentQuestionOptions", new[] { "QuestionOption_Id", "Student_Id" });
            CreateIndex("dbo.Topics", "Person_Id");
            CreateIndex("dbo.Topics", "Forum_Id");
            CreateIndex("dbo.Forums", "Course_Id");
            AddForeignKey("dbo.Topics", "Person_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Topics", "Forum_Id", "dbo.Forums", "Id");
            AddForeignKey("dbo.Forums", "Course_Id", "dbo.Courses", "Id");
            RenameTable(name: "dbo.StudentQuestionOptions", newName: "QuestionOptionStudents");
        }
    }
}
