using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Tests.ModelTests.TaskModelTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_Should_InitializePropertiescorrectly()
        {
            var constructor = new TaskModel("title", "description");

            Assert.AreEqual(constructor.Title, "title");
            Assert.AreEqual(constructor.Content, "description");
        }
    }
}
