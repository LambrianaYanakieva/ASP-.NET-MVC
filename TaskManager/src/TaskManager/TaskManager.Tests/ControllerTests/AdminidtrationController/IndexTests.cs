using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.UserServices.Contracts;
using TaskManager.Web.Areas.Administration.Models;

namespace TaskManager.Tests.ControllerTests.AdminidtrationController
{
    [TestClass]
    public class IndexTests
    {
        [TestMethod]
        public void Index_ShouldCall_GetAllUsers_Once()
        {
            var userServiceMocked = new Mock<IUserService>();


        }

        [TestMethod]
        public void Test()
        {

        }
    }
}
