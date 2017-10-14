namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Task : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskModels", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TaskModels", new[] { "User_Id" });
            AddColumn("dbo.TaskModels", "Username", c => c.String());
            DropColumn("dbo.TaskModels", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "User_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TaskModels", "Username");
            CreateIndex("dbo.TaskModels", "User_Id");
            AddForeignKey("dbo.TaskModels", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
