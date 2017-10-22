namespace TaskManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pesho : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaskModels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TaskModels", "ApplicationUser_Id");
            AddForeignKey("dbo.TaskModels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskModels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TaskModels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.TaskModels", "ApplicationUser_Id");
        }
    }
}
