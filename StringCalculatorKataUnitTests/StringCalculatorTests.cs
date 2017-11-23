using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorKataUnitTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator _stringCalculator;

        [TestInitialize]
        public void TestInitialise()
        {
            _stringCalculator = new StringCalculator();
        }

        [TestMethod]
        public void Add_ReturnsAnInt()
        {
            var result = _stringCalculator.Add("0");

            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        public void Add_WhenPassedEmtpyNumbersString_ReturnsZero()
        {
            var result = _stringCalculator.Add("");

            const int ExpectedResult = 0;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNullNumbersString_ReturnsZero()
        {
            var result = _stringCalculator.Add(null);

            const int ExpectedResult = 0;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedWhitespaceFilledNumbersString_ReturnsZero()
        {
            var result = _stringCalculator.Add(new String(' ', 10));

            const int ExpectedResult = 0;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingOneNumber_ReturnsProvidedNumber()
        {
            const int TestValue = 6;
            var result = _stringCalculator.Add(TestValue.ToString());

            Assert.AreEqual(TestValue, result);
        }
    }
}
