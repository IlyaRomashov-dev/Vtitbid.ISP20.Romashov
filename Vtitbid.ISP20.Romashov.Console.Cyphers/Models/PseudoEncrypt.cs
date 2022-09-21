using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Romashov.Console.Cyphers
{
    public class PseudoEncrypt
    {
        public static string Encrypt(string input, int repeats)
        {
            //encrypt("012345", 1)  =>  "135024"
            //encrypt("012345", 2)  =>  "135024"->  "304152"
            //encrypt("012345", 3)  =>  "135024"->  "304152"->  "012345"
            if (repeats <= 0 || string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var firstHalf = string.Empty;
            var secondHalf = string.Empty;
            for (int i = 0; i < repeats; i++)
            {
                firstHalf = string.Empty;
                secondHalf = string.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    if(j % 2 == 1)
                    {
                        firstHalf += input[j];
                    }
                    else
                    {
                        secondHalf += input[j];
                        
                    }
                }
                input = firstHalf + secondHalf;
            }
            return input;
        }

        public static string Decrypt(string input, int repeats)
        {
            if (repeats <= 0 || string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            var sb = new StringBuilder();
            var firstHalf = string.Empty;
            var secondHalf = string.Empty;
            var firstIndex = 0;
            var secondIndex = 0;
            for (int i = 0; i < repeats; i++)
            {
                firstHalf = string.Empty;
                secondHalf = string.Empty;
                firstIndex = 0;
                secondIndex = 0;
                for (int j = 0; j < input.Length; j++)      //Делим строчку на две половины
                {
                    if(j < (input.Length + 1) / 2)
                    {
                        firstHalf += input[j];
                    }
                    else
                    {
                        secondHalf += input[j];
                    }
                }
                for (int j = 0; j < input.Length; j++)     
                {
                    if (j % 2 == 1)     //Расставляем символы из первой половины по нечётным элементам
                    {
                        sb.Append(firstHalf[firstIndex]);
                        firstIndex++;
                    }
                    else    //Расставляем символы из второй половины по чётным элементам
                    {
                        sb.Append(secondHalf[secondIndex]);
                        secondIndex++;
                    }
                }
                input = sb.ToString();
                sb.Clear();
            }
            return input;

        }
    }
}
