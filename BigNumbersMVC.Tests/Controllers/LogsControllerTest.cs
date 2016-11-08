using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigNumbersMVC.Controllers;
using BigNumbersMVC.Model;
using Moq;

namespace BigNumbersMVC.Tests.Controllers
{
    [TestClass]
    public class LogsControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var loggerMock = new Mock<ILogReader>();
            loggerMock.Setup(l => l.ReadAll()).Returns(() => new[] { "logTest" });
            var controller = new LogsController(loggerMock.Object);

            ViewResult result = controller.Logs() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("logTest", ((IEnumerable<string>)result.Model).Single());
        }
    }
}
