using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using TaskManager.Data.Common.Context.Save.Contracts;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Services.UserServices
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> userRepo;
        private IPrincipal identity;
        private ISaveContext saveContext;

        public UserService(IUserRepository<ApplicationUser> userRepo, IPrincipal identity,
            ISaveContext saveContext)
        {
            Guard.WhenArgument(userRepo, "userService").IsNull().Throw();
            Guard.WhenArgument(identity, "principal").IsNull().Throw();
            Guard.WhenArgument(saveContext, "saveContext").IsNull().Throw();

            this.userRepo = userRepo;
            this.identity = identity;
            this.saveContext = saveContext;
        }

        public ApplicationUser GetUser()
        {
            var userList = this.userRepo.All().Where(x => x.UserName == identity.Identity.Name).ToList();
            var user = userList[0];
            return user;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            if (this.identity.IsInRole("Admin"))
            {
                var name = this.identity.Identity.Name;
                return this.userRepo.All().Where(x => !x.IsDeleted && x.Email != name).ToList();
            }
            else
            {
                return this.userRepo.All().Where(x => !x.IsDeleted).ToList();
            }
        }

        public void DeleteUser(string username)
        {
            var users = this.userRepo.All().Where(x => x.Email == username).ToList();
            var user = users[0];
            user.IsDeleted = true;
            this.saveContext.Commit();
        }
    }

}
