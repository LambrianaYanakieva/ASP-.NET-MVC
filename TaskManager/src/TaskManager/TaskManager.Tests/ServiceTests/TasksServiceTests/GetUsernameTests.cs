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
    public class GetUsernameTests
    {
        [TestMethod]
        public void GetUsername_ShouldReturn_IdentityUsername()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            identityMocked.Setup(x => x.Identity.Name).Returns("Pesho");
        
            var service = new TaskService(taskRepositoryMocked.Object,
                identityMocked.Object, saveContextMocked.Object);

            var username = service.GetUsername();

            Assert.AreEqual(username, identityMocked.Object.Identity.Name);           
        }
    }
}
