using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Services.UserServices
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> userRepo;
        private IPrincipal identity;

        public UserService(IUserRepository<ApplicationUser> userRepo, IPrincipal identity)
        {
            Guard.WhenArgument(userRepo, "userService").IsNull().Throw();
            Guard.WhenArgument(identity, "principal").IsNull().Throw();

            this.userRepo = userRepo;
            this.identity = identity;
        }

        public ApplicationUser GetUser()
        {
            var userList =  userRepo.All().Where(x => x.UserName == identity.Identity.Name).ToList();
            var user = userList[0];
            return user;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return this.userRepo.All().ToList();
        }


        public void DeleteUser(string username)
        {
            var users = this.userRepo.All().Where(x => x.Email == username).ToList();
            var user = users[0];
            user.IsDeleted = true;
            
        }
    }

}
