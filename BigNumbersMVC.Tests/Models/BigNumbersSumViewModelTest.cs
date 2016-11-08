using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using BigNumbersMVC.Controllers;
using BigNumbersMVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NLog;

namespace BigNumbersMVC.Tests.Models
{
    [TestClass]
    public class BigNumbersSumViewModelTest
    {
        [TestMethod]
        public void IncorrectNumbers()
        {
            var model = new BigNumbersSumViewModel()
            {
                Number2 = "2d",
                Number1 = "4.3"
            };
            var validationResut = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, new ValidationContext(model, null, null),
                validationResut, true);
            Assert.IsTrue(validationResut.Any(vr => vr.ErrorMessage == "Number 1 is not a number"));
            Assert.IsTrue(validationResut.Any(vr => vr.ErrorMessage == "Number 2 is not a number"));
        }

        [TestMethod]
        public void EmptyNumbers()
        {
            var model = new BigNumbersSumViewModel();
            var validationResut = new List<ValidationResult>();
            var result = Validator.TryValidateObject(model, new ValidationContext(model, null, null),
                validationResut, true);
            Assert.IsTrue(validationResut.Any(vr => vr.ErrorMessage == "The Number1 field is required."));
            Assert.IsTrue(validationResut.Any(vr => vr.ErrorMessage == "The Number2 field is required."));
        }
    }
}
