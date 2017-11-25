using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;
using System.Linq;

namespace StringCalculatorKataUnitTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        StringCalculator _stringCalculator;

        public string Delimiter { get; private set; }

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

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingTwoNumbers_ReturnsSumOfBothNumbers()
        {
            var result = _stringCalculator.Add("4,2");

            const int ExpectedResult = 6;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMoreThanTwoNumbers_ReturnsSumOfAllNumbers()
        {
            var testNumbers = Enumerable.Range(0, 30);
            var expectedResult = testNumbers.Sum();

            const string Delimiter = ",";
            var result = _stringCalculator.Add(string.Join(Delimiter, testNumbers));

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMultipleNumbersAndNewLineDelimiter_ReturnsSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("2\n4");

            const int ExpectedResult = 6;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMultipleNumbersAndNewLineAndCommaDelimiter_ReturnsSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("8\n8,2");

            const int ExpectedResult = 18;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringSpecifyingDelimiterAndSingleNumber_ReturnsNumberValue()
        {
            var result = _stringCalculator.Add("//;\n10");

            const int ExpectedResult = 10;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringSpecifyingDelimiterAndMultipleNumbers_ReturnsSumOfNumbers()
        {
            var result = _stringCalculator.Add("//|\n10|10|5");

            const int ExpectedResult = 25;
            Assert.AreEqual(ExpectedResult, result);
        }
    }
}
