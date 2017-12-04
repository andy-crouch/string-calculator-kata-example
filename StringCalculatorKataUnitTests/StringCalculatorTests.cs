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
        public void Add_ReturnsAnInteger()
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_WhenPassedNumbersStringContainingANegativeNumber_ThrowsArgumentException()
        {
            var result = _stringCalculator.Add("//|\n-10");
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingANegativeNumber_ThrowsArgumentExceptionWithNegativeValueInMessage()
        {
            var negativeNumber = -14;

            try
            {
                var result = _stringCalculator.Add($"//|\n{negativeNumber}");

            }
            catch (ArgumentException argumentException)
            {
                const string ExceptionMainMessage = "NEGATIVES NOT ALLOWED";

                Assert.IsTrue(argumentException.Message.ToUpper().StartsWith(ExceptionMainMessage));
                Assert.IsTrue(argumentException.Message.ToUpper().Contains(negativeNumber.ToString()));
            }
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingANegativeNumbers_ThrowsArgumentExceptionWithNegativeValuesInMessage()
        {
            var negativeNumbers = "-12|-18|-17";

            try
            {
                var result = _stringCalculator.Add($"//|\n{negativeNumbers}");

            }
            catch (ArgumentException argumentException)
            {
                const string ExceptionMainMessage = "NEGATIVES NOT ALLOWED";

                Assert.IsTrue(argumentException.Message.ToUpper().StartsWith(ExceptionMainMessage));
                Assert.IsTrue(argumentException.Message.ToUpper().Contains(negativeNumbers.Replace("|", ",")));
            }
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingNumbersLargerThanAThousand_ReturnSumOfNumbersLessThanAThousand()
        {
            var result = _stringCalculator.Add("//|\n1050|10|5");

            const int ExpectedResult = 15;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingNumbersEqualToAThousand_ReturnSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("//|\n1000|10|5");

            const int ExpectedResult = 1015;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMultplieNumbersWithVariableLengthDelimiter_ReturnsSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("//[***]\n10***90***15");

            const int ExpectedResult = 115;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMultplieNumbersWithMultipleSingleLengthDelimiters_ReturnsSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("//[*][%]\n1*2%3");

            const int ExpectedResult = 6;
            Assert.AreEqual(ExpectedResult, result);
        }

        [TestMethod]
        public void Add_WhenPassedNumbersStringContainingMultplieNumbersWithMultipleVariableLengthDelimiters_ReturnsSumOfAllNumbers()
        {
            var result = _stringCalculator.Add("//[**][%%%%]\n130**260%%%%20**10");

            const int ExpectedResult = 420;
            Assert.AreEqual(ExpectedResult, result);
        }
    }
}
