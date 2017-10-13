namespace TaskManager.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using TaskManager.Models;


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}