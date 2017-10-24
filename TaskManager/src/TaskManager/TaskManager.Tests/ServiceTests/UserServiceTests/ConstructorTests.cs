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
using TaskManager.Services.UserServices;

namespace TaskManager.Tests.ServiceTests.UserServiceTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldSet_ParametersCorrectly()
        {
            var userRepositoryMocked = new Mock<IUserRepository<ApplicationUser>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            var service = new UserService(userRepositoryMocked.Object, identityMocked.Object,
                saveContextMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameterUserRepo_IsNull()
        {
            var saveContextMocked = new Mock<ISaveContext>();
            var identity = new Mock<IPrincipal>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(null,identity.Object,
                    saveContextMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameterIdentity_IsNull()
        {
            var userRepositoryMocked = new Mock<IUserRepository<ApplicationUser>>();
            var saveContextMocked = new Mock<ISaveContext>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(userRepositoryMocked.Object, null,
                    saveContextMocked.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameterSaveContect_IsNull()
        {
            var userRepositoryMocked = new Mock<IUserRepository<ApplicationUser>>();
            var identity = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(userRepositoryMocked.Object, identity.Object,
                    null));
        }
    }
}
