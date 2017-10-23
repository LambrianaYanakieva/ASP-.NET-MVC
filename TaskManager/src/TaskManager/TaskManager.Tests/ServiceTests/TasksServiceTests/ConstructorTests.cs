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
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldSet_ParametersCorrectly()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();

            var service = new TaskService(taskRepositoryMocked.Object, 
                identityMocked.Object, saveContextMocked.Object, userServiceMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_ShouldThrowException_WhenRepositoryIsNull()
        {
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new TaskService(null, identityMocked.Object, 
                    saveContextMocked.Object,userServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowException_WhenIdentityIsNull()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var saveContextMocked = new Mock<ISaveContext>();
            var userServiceMocked = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new TaskService(taskRepositoryMocked.Object, null,
                    saveContextMocked.Object,userServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowException_WhenSaveContextIsNull()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var userServiceMocked = new Mock<IUserService>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new TaskService(taskRepositoryMocked.Object, identityMocked.Object,
                    null,userServiceMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrowException_WhenUserServiceIsNull()
        {
            var taskRepositoryMocked = new Mock<IDbRepository<TaskModel>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new TaskService(taskRepositoryMocked.Object, identityMocked.Object,
                    saveContextMocked.Object, null));
        }
    }
}
