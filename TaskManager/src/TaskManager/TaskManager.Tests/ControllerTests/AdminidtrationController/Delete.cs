using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskManager.Models;
using TaskManager.Services.UserServices.Contracts;
using TaskManager.Web.Areas.Administration.Controllers;
using TestStack.FluentMVCTesting;

namespace TaskManager.Tests.ControllerTests.AdminidtrationController
{
    [TestClass]
    public class Delete
    {
        [TestMethod]
        public void Delete_ShouldCall_DeleteUserOnce()
        {
            var userServiceMocked = new Mock<IUserService>();

            userServiceMocked.Setup(x => x.GetAllUsers()).Returns(new List<ApplicationUser>()
            {

            });

            var controller = new AdministrationController(userServiceMocked.Object);

            controller.Delete("Pesho");

            userServiceMocked.Verify(x => x.DeleteUser("Pesho"), Times.Once);
        }

        [TestMethod]
        public void Delete_ShouldReturn_Action_FromType_ActionResult()
        {
            var userServiceMocked = new Mock<IUserService>();

            userServiceMocked.Setup(x => x.GetAllUsers()).Returns(new List<ApplicationUser>()
            {

            });

            var controller = new AdministrationController(userServiceMocked.Object);


            controller.WithCallTo(x => x.Delete("Pesho"))
                .ValidateActionReturnType<RedirectToRouteResult>();
               

        }
    }
}
