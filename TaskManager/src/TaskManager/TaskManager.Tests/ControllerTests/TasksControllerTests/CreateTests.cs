using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Web.Models.Task;
using TaskManager.Web.Controllers;
using TestStack.FluentMVCTesting;
using System.Web.Mvc;

namespace TaskManager.Tests.ControllerTests.TasksControllerTests
{
    [TestClass]
    public class CreateTests
    {
        [TestMethod]
        public void Create_ShouldCall_AddTaskOnce()
        {
            var taskServiceMocked = new Mock<ITaskService>();

            var taskModelDemo = new TaskModel()
            {
                Title = "TestTitle",
                Content = "TestContent"
            };

            var taskViewModel = new TaskViewModel()
            {
                Title = taskModelDemo.Title,
                Content = taskModelDemo.Content
            };

            taskServiceMocked.Setup(x => x.GetAll()).Returns(
                new List<TaskModel>()
                {
                   taskModelDemo
                });

            var controller = new TasksController(taskServiceMocked.Object);
           
            controller.Create(taskModelDemo);

            taskServiceMocked.Verify(x => x.AddTask(taskModelDemo), Times.Once);
        }


        [TestMethod]
        public void Create_ShouldReturnList_With_TaskViewModel()
        {
            var taskServiceMocked = new Mock<ITaskService>();

            var taskModelDemo = new TaskModel()
            {
                Title = "TestTitle",
                Content = "TestContent"
            };

            var taskViewModel = new TaskViewModel()
            {
                Title = taskModelDemo.Title,
                Content = taskModelDemo.Content
            };

            taskServiceMocked.Setup(x => x.GetAll()).Returns(
                new List<TaskModel>()
                {
                   taskModelDemo
                });

            var controller = new TasksController(taskServiceMocked.Object);

            controller.WithCallTo(x => x.Create(taskModelDemo))
                .ValidateActionReturnType<RedirectToRouteResult>();
        }

    }
}
