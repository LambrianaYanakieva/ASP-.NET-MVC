using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Services.TaskServices;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Web.Models.Task;

namespace TaskManager.Web.Controllers
{
    public class TasksController : Controller
    {
        private ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            Guard.WhenArgument(taskService,"TaskService").IsNull().Throw();
            this.taskService = taskService;
        }


        public ActionResult Index()
        {
            var taskCollection = taskService.GetAll().Select(x => new TaskViewModel()
            {
                Title = x.Title,
                Content = x.Content,
                
            }).ToList();

            return View(taskCollection);
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            model.Username = taskService.GetUsername();
            this.taskService.AddTask(model);
            return RedirectToAction("Index");
        }

        public ActionResult RenderTask()
        {
            return View();
        }
    }
}