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


            const char Delimiter = ',';

            return numbers
                    .Split(new char[] { Delimiter })
                    .Select(stringNumber => Convert.ToInt32(stringNumber))
                    .Sum();
        }

        private bool IsNullEmptyOrWhitespaceFilled(string numbers)
        {
            return string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers);
        }
    }
}
