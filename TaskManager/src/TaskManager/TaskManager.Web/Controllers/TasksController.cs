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
        private TaskService service;

        public TasksController(TaskService taskService)
        {
            this.service = taskService;
        }


        public ActionResult Index()
        {
            var taskCollection = service.GetAll().Select(x => new TaskViewModel()
            {
                Title = x.Title,
                Content = x.Content,
                
            }).ToList();

            return View(taskCollection);
        }

        [HttpPost]
        public ActionResult Create(TaskModel model)
        {
            model.Username = service.GetUsername();
            this.service.AddTask(model);
            return RedirectToAction("Index");
        }

        public ActionResult RenderTask()
        {
            return View();
        }
    }
}