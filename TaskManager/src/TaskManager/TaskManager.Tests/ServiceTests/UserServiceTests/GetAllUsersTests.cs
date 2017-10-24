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
    public class GetAllUsersTests
    {
        [TestMethod]
        public void GetAllUsers_ShouldCall_MethodAll_Once()
        {
            var repoMocked = new Mock<IUserRepository<ApplicationUser>>();
            var identityMocked = new Mock<IPrincipal>();
            var saveContextMocked = new Mock<ISaveContext>();

            var users = new List<ApplicationUser>();

            repoMocked.Setup(m => m.All()).Returns(users.AsQueryable());

            var service = new UserService(repoMocked.Object, identityMocked.Object,
                saveContextMocked.Object);

            service.GetAllUsers();

            repoMocked.Verify(m => m.All(), Times.Once);
        }
    }
}
