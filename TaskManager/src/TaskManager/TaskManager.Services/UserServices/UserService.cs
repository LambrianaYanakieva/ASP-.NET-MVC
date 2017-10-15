using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Services.UserServices
{
    public class UserService : IUserService
    {
        private IUserRepository<ApplicationUser> userRepo;

        public UserService(IUserRepository<ApplicationUser> userRepo)
        {
            Guard.WhenArgument(userRepo, "userService").IsNull().Throw();
            this.userRepo = userRepo;
        }

        public ICollection<ApplicationUser> GetAllUsers()
        {
            return this.userRepo.All().ToList();
        }


        public void DeleteUser(string username)
        {
            var user = this.userRepo.All().Where(x => x.Email == username).ToList();
            this.userRepo.HardDelete(user[0]);
        }
    }
}
