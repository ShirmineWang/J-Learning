namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIsAdmin : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "IsAdmin", c => c.Boolean(nullable: false));
        }
    }
}
