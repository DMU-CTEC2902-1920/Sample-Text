using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dmuBlogger.Controllers;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using dmuBlogger.Models;
using dmuBlogger.Data;

namespace dmuBloggerTest
{
    [TestClass]
    public class tstDevelopersController
    {
        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new DevelopersController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
