using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;

namespace TaskManager.Services.UserServices
{
    public class UserService
    {
        private IDbRepository<ApplicationUser> user;

        public UserService(IDbRepository<ApplicationUser> user)
        {
            this.user = user;
        }
    }
}
