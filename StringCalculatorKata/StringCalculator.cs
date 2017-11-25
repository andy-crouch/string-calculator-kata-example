using System;
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

            return numbers
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                    .Select(stringNumber => Convert.ToInt32(stringNumber))
                    .Sum();
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
