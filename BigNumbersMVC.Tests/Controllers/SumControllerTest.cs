using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BigNumbersMVC.Controllers;
using BigNumbersMVC.Models;
using Moq;
using NLog;

namespace BigNumbersMVC.Tests.Controllers
{
    [TestClass]
    public class SumControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new SumController(new Mock<ILogger>().Object);

            ViewResult result = controller.Sum() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Sum()
        {
            var model = new BigNumbersSumViewModel()
            {
                Number1 = "1",
                Number2 = "2",
            };
            var loggerMock = new Mock<ILogger>();
            string loggedMessage = null;
            loggerMock.Setup(l => l.Log(It.IsAny<LogLevel>(), It.IsAny<string>()))
                        .Callback<LogLevel, string>((level, message) =>
                        {
                            loggedMessage = message;
                        });
            var controller = new SumController(loggerMock.Object);

            ViewResult result = controller.Sum(model) as ViewResult;
            Assert.IsNotNull(result);

            Assert.AreEqual("3", model.Result);
            
            Assert.AreEqual("1, 2, 3", loggedMessage);
        }

        [TestMethod]
        public void SumInvalidModel()
        {
            var model = new BigNumbersSumViewModel()
            {
                Number1 = "1d",
                Number2 = "d2",
            };
            var loggerMock = new Mock<ILogger>();
            string loggedMessage = null;
            loggerMock.Setup(l => l.Log(It.IsAny<LogLevel>(), It.IsAny<string>()))
                        .Callback<LogLevel, string>((level, message) =>
                        {
                            loggedMessage = message;
                        });
            var controller = new SumController(loggerMock.Object);
            controller.ViewData.ModelState.AddModelError("Key", "ErrorMessage");

            ViewResult result = controller.Sum(model) as ViewResult;
            Assert.IsNotNull(result);

            Assert.AreEqual(null, ((BigNumbersSumViewModel)result.Model).Result);

            Assert.AreEqual(null, loggedMessage);
        }
    }
}
