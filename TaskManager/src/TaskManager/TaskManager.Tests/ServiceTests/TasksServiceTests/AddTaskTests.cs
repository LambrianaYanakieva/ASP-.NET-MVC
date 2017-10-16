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

            identityMocked.Setup(x => x.Identity.Name).Returns("Pesho");

            var tasks = new List<TaskModel>();

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object);

            var model = new TaskModel();

            model.Username = identityMocked.Name;

            service.AddTask(model);

            taskRepositoryMocked.Verify(x => x.Add(model), Times.Once);
        }

        [TestMethod]
        public void AddTask_ShouldCall_MethodSaveContext_Once()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            identityMocked.Setup(x => x.Identity.Name).Returns("Pesho");

            var tasks = new List<TaskModel>();

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object);

            var model = new TaskModel();

            model.Username = identityMocked.Name;

            service.AddTask(model);

            saveContextMocked.Verify(x => x.Commit(), Times.Once);
        }

        [TestMethod]
        public void Demo_Test()
        {

        }
    }
}
