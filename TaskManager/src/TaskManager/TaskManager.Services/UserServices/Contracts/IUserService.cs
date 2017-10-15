using System.Collections.Generic;
using TaskManager.Models;

namespace TaskManager.Services.UserServices.Contracts
{
    public interface IUserService
    {
        ICollection<ApplicationUser> GetAllUsers();

        void DeleteUser(string username);
    }
}
