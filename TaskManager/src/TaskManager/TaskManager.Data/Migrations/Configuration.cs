namespace TaskManager.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManager.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManager.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TaskManager.Data.ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };

                roleManager.Create(role);

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser
                {
                    UserName = "task@telerikacademy.com",
                    Email = "task@telerikacademy.com",
                    EmailConfirmed = true
                };

                userManager.Create(user, "123456");
                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
