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
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_ShouldReturnTaskWithUnit()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();        

            var task = new TaskModel() { Title = "testTask" };

            var tasksTest = new List<TaskModel>();
            tasksTest.Add(task);

            var user = new Mock<ApplicationUser>();
            user.Setup(m => m.Email).Returns("test");
            user.Setup(m => m.Tasks).Returns(tasksTest);

            userServiceMocked.Setup(m => m.GetUser())
              .Returns( user.Object );

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object, userServiceMocked.Object);

            var result = service.GetAll();

            Assert.AreEqual(result.First().Title, "testTask");         
        }

        [TestMethod]
        public void GetAll_ShouldCall_GetUser_Once()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();

            var task = new TaskModel() { Title = "testTask" };

            var tasksTest = new List<TaskModel>();
            tasksTest.Add(task);

            var user = new Mock<ApplicationUser>();
            user.Setup(m => m.Email).Returns("test");
            user.Setup(m => m.Tasks).Returns(tasksTest);

            userServiceMocked.Setup(m => m.GetUser())
              .Returns(user.Object);

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object, userServiceMocked.Object);

            var result = service.GetAll();

            userServiceMocked.Verify(x => x.GetUser(), Times.Once);
        }
    }
}
