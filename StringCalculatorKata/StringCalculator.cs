using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const string DelimiterLineStartMarker = "//";
        private const string DelimiterLineEndMarker = "\n";

        public int Add(string numbers)
        {
            if (IsNullEmptyOrWhitespaceFilled(numbers))
                return 0;

            var delimiters = GetDelimitersFrom(numbers);
            numbers = RemoveDelimiterDataFrom(numbers);

            const int MaxNumberToCalculate = 1000;

            var integerNumbers
                = numbers
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Where(stringNumber => Convert.ToInt32(stringNumber) <= MaxNumberToCalculate)
                    .Select(stringNumber => Convert.ToInt32(stringNumber));

            Validate(integerNumbers);

            return integerNumbers.Sum();
        }

        private void Validate(IEnumerable<Int32> numbers)
        {
            var negativeNumbers
                 = numbers
                    .Where(number => number < 0)
                    .Select(number => number)
                    .ToList();

            if( negativeNumbers.Any())
            {
                const string ExceptionMainMessage = "Negatives Not Allowed";

                var exceptionMessage 
                    = $"{ExceptionMainMessage} = {string.Join(",", negativeNumbers)}";

                throw new ArgumentException(exceptionMessage);
            }
        }

        private bool IsNullEmptyOrWhitespaceFilled(string numbers)
        {
            return string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers);
        }

        private string[] GetDelimitersFrom(string numbers)
        {
            if (numbers.StartsWith(DelimiterLineStartMarker) && 
                numbers.Contains(DelimiterLineEndMarker))
            {
                var delimiterString = numbers.Substring(2, 1);
                return new string[] { delimiterString };
            }

            return new string[] { ",", "\n" };
        }

        private string RemoveDelimiterDataFrom(string numbers)
        {
            if (numbers.StartsWith(DelimiterLineStartMarker))
            {
                int start = numbers.IndexOf(DelimiterLineEndMarker) + 1;
                return numbers.Substring(start);
            }

            return numbers;
        }

    }
}
