using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers) || string.IsNullOrWhiteSpace(numbers))
                return 0;

            return Convert.ToInt32(numbers);
        }
    }
}
