using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Common.Context.Save.Contracts;
using TaskManager.Data.Common.Repositories.Contracts;
using TaskManager.Models;
using TaskManager.Services.TaskServices;
using TaskManager.Services.UserServices.Contracts;

namespace TaskManager.Tests.ServiceTests.TasksServiceTests
{
    [TestClass]
    public class AddTaskTests
    {
        [TestMethod]
        public void AddTask_ShouldCall_MethodAdd_Once()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();
            identityMocked.Setup(x => x.Identity.Name).Returns("Pesho");
            var userMocked = new Mock<ApplicationUser>();            
            var tasks = new List<TaskModel>();
            userMocked.Setup(m => m.Tasks).Returns(tasks);
            userMocked.Setup(m => m.Email).Returns("test");

            userServiceMocked.Setup(m => m.GetUser())
                .Returns(userMocked.Object);           

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object, userServiceMocked.Object);

            var model = new TaskModel();

            service.AddTask(model);

            Assert.AreEqual(tasks.Count, 1);
        }

        [TestMethod]
        public void AddTask_ShouldCall_MethodSaveContext_Once()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();
            var userMocked = new Mock<ApplicationUser>();
            identityMocked.Setup(x => x.Identity.Name).Returns("Pesho");
            
            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object, userServiceMocked.Object);

            var model = new TaskModel();
            var tasks = new List<TaskModel>();
            userMocked.Setup(x => x.Tasks).Returns(tasks);
            userServiceMocked.Setup(x => x.GetUser()).Returns(userMocked.Object);
            service.AddTask(model);
            
            saveContextMocked.Verify(x => x.Commit(), Times.Once);
        }

        [TestMethod]
        public void Demo_Test()
        {

        }
    }
}
