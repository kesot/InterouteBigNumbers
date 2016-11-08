using System;
using BigNumbersMVC.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigNumbersMVC.Tests
{
    [TestClass]
    public class BigNumbersHelperTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionNumber1()
        {
            BigNumbersHelper.Sum(null, "12");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ArgumentNullExceptionNumber2()
        {
            BigNumbersHelper.Sum("12", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentExceptionNumber1()
        {
            BigNumbersHelper.Sum("d", "12");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ArgumentExceptionNumber2()
        {
            BigNumbersHelper.Sum("12", "d");
        }

        [TestMethod]
        public void CorrectSum()
        {
            Assert.AreEqual("24", BigNumbersHelper.Sum("12", "12"));
        }

        [TestMethod]
        public void CorrectSumNegativeNumber()
        {
            Assert.AreEqual("10", BigNumbersHelper.Sum("12", "-2"));
        }

        [TestMethod]
        public void CorrectSumNegativeNumberNegativeResult()
        {
            Assert.AreEqual("-14", BigNumbersHelper.Sum("-12", "-2"));
        }

        [TestMethod]
        public void BigNumbersOk()
        {
            Assert.AreEqual("222222455555555555553333333333333333333333333344444444444444", BigNumbersHelper.Sum("233333333333331111111111111111111111111111111111111111", "222222222222222222222222222222222222222222222233333333333333"));
        }
    }
}