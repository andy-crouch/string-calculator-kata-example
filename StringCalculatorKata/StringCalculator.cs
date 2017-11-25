using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(IsNullEmptyOrWhitespaceFilled(numbers))
                return 0;

            var delimiters = new char[] { ',', '\n' };

            return numbers
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(stringNumber => Convert.ToInt32(stringNumber))
                    .Sum();
        }

        private bool IsNullEmptyOrWhitespaceFilled(string numbers)
        {
            return string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers);
        }
    }
}
