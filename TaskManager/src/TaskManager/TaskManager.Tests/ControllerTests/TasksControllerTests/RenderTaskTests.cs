using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace TaskManager.Tests.ControllerTests.TasksControllerTests
{
    [TestClass]
    public class RenderTaskTests
    {
        [TestMethod]
        public void RenderTask_ShouldReturnDefaultView()
        {
            var taskServiceMocked = new Mock<ITaskService>();

            var controller = new TasksController(taskServiceMocked.Object);

            controller.WithCallTo(x => x.RenderTask())
                .ShouldRenderDefaultView();
                
        }
    }
}
