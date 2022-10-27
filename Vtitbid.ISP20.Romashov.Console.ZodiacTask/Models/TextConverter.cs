using System;

namespace Vtitbid.ISP20.Romashov.Console.ZodiacTask.Models
{
    class TextConverter
    {
        public static DateTime StringToDate(string input)
        {
            int i = 0;
            string day = string.Empty;
            string month = string.Empty;
            string year = string.Empty;

            while (Char.IsDigit(input[i]) && i < input.Length)
            {
                day += input[i++];
            }
            i++;
            while (Char.IsDigit(input[i]) && i < input.Length)
            {
                month += input[i++];
            }
            i++;
            while (Char.IsDigit(input[i]) && i < input.Length)
            {
                year += input[i++];
            }
            return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
        }
    }
}
