using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var service = new UserService(userRepositoryMocked.Object);

            Assert.IsNotNull(service);
        }

        [TestMethod]
        public void Constructor_ShouldThrow_WhenParameter_IsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
                    new UserService(null));
        }
    }
}
