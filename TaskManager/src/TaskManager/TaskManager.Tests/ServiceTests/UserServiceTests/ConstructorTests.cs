using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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

            var service = new UserService(userRepositoryMocked.Object, identityMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameterUserRepo_IsNull()
        {
            var identity = new Mock<IPrincipal>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(null,identity.Object));
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameterIdentity_IsNull()
        {
            var userRepositoryMocked = new Mock<IUserRepository<ApplicationUser>>();

            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(userRepositoryMocked.Object, null));
        }
    }
}
