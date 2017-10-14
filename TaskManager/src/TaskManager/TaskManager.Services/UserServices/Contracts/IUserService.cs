using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services.UserServices.Contracts
{
    public interface IUserService
    {
        List<ApplicationUser> All { get; }
    }
}
