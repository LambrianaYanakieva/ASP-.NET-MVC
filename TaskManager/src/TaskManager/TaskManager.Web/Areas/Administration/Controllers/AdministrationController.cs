using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using TaskManager.Services.UserServices.Contracts;
using TaskManager.Web.Areas.Administration.Models;

namespace TaskManager.Web.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        private IUserService userService;

        public AdministrationController(IUserService service)
        {
            Guard.WhenArgument(service, "User service cannot be null!").IsNull().Throw();
            this.userService = service;
        }

        // GET: Administration/Administration
        public ActionResult Index()
        {
            var users = this.userService.GetAllUsers()
                .Select(u => new UserViewModel()
                {
                    Username = u.Email
                });
                

            return View(users);
        }

        [HttpPost]
        public ActionResult Delete(string username)
        {
            this.userService.DeleteUser(username);
            return RedirectToAction("Index");
        }
    }
}