using System.Web.Mvc;

namespace TaskManager.Web.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration/Administration
        public ActionResult Index()
        {
            return View();
        }
    }
}