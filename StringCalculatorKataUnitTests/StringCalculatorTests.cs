using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorKataUnitTests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_ReturnsAnInt()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("0");

            Assert.IsInstanceOfType(result, typeof(int));
        }
    }
}
