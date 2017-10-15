using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.UserServices.Contracts;
using TaskManager.Web.Areas.Administration.Controllers;

namespace TaskManager.Tests.ControllerTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldSet_PropriesCorrectly()
        {
            var userServiceMocked = new Mock<IUserService>();

            var controller = new AdministrationController(userServiceMocked.Object);

            Assert.IsNotNull(controller);
        }

        [TestMethod]
        public void Constructor_ShouldThrowException_WhenArgumentIsNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            new AdministrationController(null));
        }
    }
}
