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
    public class GetAllTests
    {
        [TestMethod]
        public void GetAll_ShouldCall_MethodAll_Once()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            
            var tasks = new List<TaskModel>();

            taskRepositoryMocked.Setup(x => x.All()).Returns(tasks.AsQueryable());

            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object);

            service.GetAll();

            taskRepositoryMocked.Verify(x => x.All(), Times.Once);
        }
    }
}
