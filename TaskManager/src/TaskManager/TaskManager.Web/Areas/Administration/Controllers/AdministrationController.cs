using System.Web.Mvc;
using TaskManager.Services.UserServices.Contracts;


namespace TaskManager.Web.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        private IUserService userService;

        public AdministrationController(IUserService service)
        {
            this.userService = service;
        }

        // GET: Administration/Administration
        public ActionResult Index()
        {                      
            return View();
        }
    }
}