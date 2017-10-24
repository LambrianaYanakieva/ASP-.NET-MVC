using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TaskManager.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace TaskManager.Tests.ControllerTests.ErrorControllerTests
{
    [TestClass]
    public class Index
    {
        [TestMethod]
        public void Index_Should_ReturnDefaultView()
        {
            var controller = new ErrorController();
            //controller.Response.ContentType = "text/html";
            controller.WithCallTo(x => x.Index()).ShouldRenderDefaultView();
               
        }
    }
}
