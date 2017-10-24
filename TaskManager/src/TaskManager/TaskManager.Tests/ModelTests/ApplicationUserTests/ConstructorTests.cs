using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Tests.ModelTests.ApplicationUserTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Constructor_ShouldIntialize_PropertiesCorrectly()
        {
            var constructor = new ApplicationUser();

            Assert.IsNotNull(constructor.CreatedOn);
            Assert.IsNotNull(constructor.DeletedOn);
            Assert.IsNotNull(constructor.IsDeleted);
            Assert.IsNotNull(constructor.ModifiedOn);
            Assert.IsNotNull(constructor.Tasks);
        }

        [TestMethod]
        public void Constructor_ShouldSet_isDeletedCorrectly()
        {
            var constructor = new ApplicationUser();
            constructor.IsDeleted = true;
            Assert.AreEqual(true, constructor.IsDeleted);
           
        }

        [TestMethod]
        public void Constructor_ShouldSet_CreatedOnCorrectly()
        {
            var constructor = new ApplicationUser();
            var date = new DateTime(1997, 09, 08);
            constructor.CreatedOn = date;
            Assert.AreEqual(date, constructor.CreatedOn);

        }

        [TestMethod]
        public void Constructor_ShouldSet_DeletedOnCorrectly()
        {
            var constructor = new ApplicationUser();
            var date = new DateTime(1997, 09, 08);
            constructor.DeletedOn = date;
            Assert.AreEqual(date, constructor.DeletedOn);

        }

        [TestMethod]
        public void Constructor_ShouldSet_ModifiedOnCorrectly()
        {
            var constructor = new ApplicationUser();
            var date = new DateTime(1997, 09, 08);
            constructor.ModifiedOn = date;
            Assert.AreEqual(date, constructor.ModifiedOn);

        }

        [TestMethod]
        public void Constructor_ShouldSet_TasksCorrectly()
        {
            var constructor = new ApplicationUser();
            var tasks = new HashSet<TaskModel>();
            constructor.Tasks = tasks;
            Assert.AreEqual(tasks, constructor.Tasks);
        }
    }
}
