using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.TaskServices.Contracts;
using TaskManager.Web.Controllers;

namespace TaskManager.Tests.ControllerTests
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void Constructor_ShoulSetParametersCorrectly()
        {
            var taskServiceMocked = new Mock<ITaskService>();

            var controller = new TasksController(taskServiceMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_ArgumentNullException_WhenServiceIsNull()
        {
            var taskServiceMocked = new Mock<ITaskService>();
            Assert.ThrowsException<ArgumentNullException>(()
                => new TasksController(null));
        }
    }
}
