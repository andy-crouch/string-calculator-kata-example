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
            if(NoDelimiterDataExistsIn(numbers))
                return new string[] { ",", "\n" };

            const string DelimiterOpeningBracket = "[";
            const string DelimiterEndBracket = "[";
            const int DelimiterDataStartPosition = 2;

            int delimiterDataLength 
                = numbers.IndexOf(DelimiterLineEndMarker) - DelimiterDataStartPosition;

            var delimiterData = numbers.Substring(DelimiterDataStartPosition, delimiterDataLength);

            if(delimiterData.Contains(DelimiterOpeningBracket) || 
               delimiterData.Contains(DelimiterEndBracket))
            {
                const string DelimiterListSeperator = "][";
                const int DelimiterListStartPosition = 1;
                const int DelimiterListEndAdjustment = 2;

                delimiterData = delimiterData
                    .Substring(DelimiterListStartPosition, delimiterData.Length - DelimiterListEndAdjustment);

                return delimiterData
                        .Split(new string[] { DelimiterListSeperator }, StringSplitOptions.RemoveEmptyEntries);
            }

            const int DefaultDelimiterLength = 1;
            var delimiterString = numbers.Substring(DelimiterDataStartPosition, DefaultDelimiterLength);

            return new string[] { delimiterString };
        }

        private bool NoDelimiterDataExistsIn(string numbers)
        {
            return !numbers.StartsWith(DelimiterLineStartMarker);
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
