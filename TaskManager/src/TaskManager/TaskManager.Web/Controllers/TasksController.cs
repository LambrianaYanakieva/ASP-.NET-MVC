using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Services.TaskServices;
using TaskManager.Web.Models.Task;

namespace TaskManager.Web.Controllers
{
    public class TasksController : Controller
    {
        private TaskListService service;

        public TasksController(TaskListService taskService)
        {
            this.service = taskService;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            this.service.AddTask(model);
            return RedirectToAction("Index");
        }

        public ActionResult RenderTask()
        {
            return View();
        }
    }
}