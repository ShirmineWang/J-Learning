namespace J_LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTitleForVideo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "Title");
        }
    }
}
