using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using dmuBlogger.Controllers;
using dmuBlogger.Data;
using dmuBlogger.Models;

namespace dmuBloggerTest
{
    [TestClass]
    public class tstDeveloper
    {
        [TestMethod]
        public void TestMethod2()
        {
            var controller = new DevelopersController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
