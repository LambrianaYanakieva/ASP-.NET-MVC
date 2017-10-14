using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Services.UserServices
{
    public class UserService : IUserService
    {
        private IDbRepository<ApplicationUser> userRepo;

        public UserService(IDbRepository<ApplicationUser> userRepo)
        {
            this.userRepo = userRepo;
        }

        public List<ApplicationUser> All => this.userRepo.All().ToList();
    }
}
