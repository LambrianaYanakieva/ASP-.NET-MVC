using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Web.Controllers;
using TaskManager.Web.Models.Task;
using TestStack.FluentMVCTesting;

namespace TaskManager.Tests.ControllerTests
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ShouldReturnList_With_TaskViewModel()
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

            controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<TaskViewModel>>(taskModel =>
                {
                    Assert.AreEqual(taskModel.First().Title, taskViewModel.Title);
                    Assert.AreEqual(taskModel.First().Content, taskViewModel.Content);
                });
        }

        [TestMethod]
        public void Index_ShouldCall_GetAll_Once()
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

            controller.Index();

            taskServiceMocked.Verify(x => x.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Index_ShouldReturn_EmptyList_WhenThereAreNoModels()
        {
            var taskServiceMocked = new Mock<ITaskService>();
         
            var taskViewModel = new TaskViewModel();
 
            taskServiceMocked.Setup(x => x.GetAll()).Returns(
                new List<TaskModel>());

            var controller = new TasksController(taskServiceMocked.Object);

            controller
                .WithCallTo(x => x.Index())
                .ShouldRenderDefaultView()
                .WithModel<List<TaskViewModel>>(viewModel =>
                {
                    Assert.AreEqual(viewModel.Count, 0);
                });
        }
    }
}
