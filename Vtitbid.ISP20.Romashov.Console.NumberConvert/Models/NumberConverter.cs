using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vtitbid.ISP20.Romashov.Console.Converter
{
    static class NumberConverter
    {
        static string[] _endingWordsDefault = new string[] { "", "", "" };
        static string[] _endingWordsThousands = new string[] { "тысяча", "тысячи", "тысяч" };
        static string[] _endingWordsMillions = new string[] { "миллион", "миллиона", "миллионов" };
        static string[] _endingWordsBillions = new string[] { "миллиард", "миллиарда", "миллиардов" };
        static string[] _endingWordsTrillions = new string[] { "триллион", "триллиона", "триллионов" };
        static string[] _endingWordsQuadrillions = new string[] { "квадриллион", "квадриллиона", "квадриллионов" };
        static string[] _endingWordsQuintillion = new string[] { "квинтиллион", "квинтиллиона", "квинтиллионов" };
        static string[] _endingWordsSextillion = new string[] { "секстиллион", "секстиллиона", "секстиллионов" };
        static string[] _endingWordsSeptillion = new string[] { "септиллион", "септиллиона", "секстиллионов" };
        static string[] _endingWordsOctillion = new string[] { "октиллион", "окктиллиона", "октиллионов" };
        static string[] _endingWordsNonillion = new string[] { "нониллион", "нониллиона", "нониллионов" };
        static string[] _endingWordsDecillion = new string[] { "дециллион", "дециллиона", "дециллионов" };

        static string[][] _endingWords = new string[][] { _endingWordsDefault, _endingWordsThousands, _endingWordsMillions, _endingWordsBillions, _endingWordsTrillions, _endingWordsQuadrillions, _endingWordsQuintillion, _endingWordsSextillion, _endingWordsSeptillion, _endingWordsOctillion, _endingWordsNonillion, _endingWordsDecillion };
        public static string Int32ToWords(int input)
        {
            return StringNumberToWords(input.ToString());
        }
        public static string Int64ToWords(long input)
        {
            return StringNumberToWords(input.ToString());
        }
        public static string StringNumberToWords(string input)
        {
            foreach (var symbol in input)
            {
                if (!char.IsDigit(symbol) || input.Length > _endingWords.Length * 3)
                {
                    return double.NaN.ToString();
                }
            }
            if (input == "0")
            {
                return "ноль";
            }
            string[] intermediante = CategoriesDivision(input);
            string number;
            string word;
            for (int i = 0; i < intermediante.Length; i++)
            {
                number = NumberUpTo999ToString(intermediante[i], CheckEndingByCategory(i));
                word = _endingWords[i][CheckEndingByNumber(intermediante[i])];
                if (number == "000" || String.IsNullOrEmpty(number))
                {
                    word = "";
                }
                intermediante[i] = $"{number} {word}";
            }
            Array.Reverse(intermediante);
            string result = string.Empty;
            foreach (var item in intermediante)
            {
                if (String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item))
                {
                    continue;
                }
                result += $"{item.Trim()} ";
            }
            return result.Trim();

        }

        public static string[] CategoriesDivision(string input)
        {
            var sb = new StringBuilder();
            if (input.Length % 3 != 0)
            {
                for (int i = 0; i < 3 - (input.Length % 3); i++)
                {
                    sb.Append("0");
                }
            }
            sb.Append(input);
            string[] output = new string[sb.Length / 3];
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = String.Empty;
            }
            for (int i = 0, j = 0; i < sb.Length; i++)
            {
                if (output[j].Length >= 3)
                {
                    j++;
                }
                output[j] += sb[i];
            }
            Array.Reverse(output);
            return output;
        }

        static string NumberUpTo999ToString(string input)
        {
            var sb = new StringBuilder();
            string number = "";
            if (input.Length % 3 != 0)
            {
                for (int i = 0; i < 3 - (input.Length % 3); i++)
                {
                    number += "0";
                }
            }
            number += input;
            try
            {
                if (Convert.ToInt32(number) > 999)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            switch (number[0])
            {
                case '0':
                    break;
                case '1':
                    sb.Append("сто ");
                    break;
                case '2':
                    sb.Append("двести ");
                    break;
                case '3':
                    sb.Append("триста ");
                    break;
                case '4':
                    sb.Append("четыреста ");
                    break;
                case '5':
                    sb.Append("пятьсот ");
                    break;
                case '6':
                    sb.Append("шестьсот ");
                    break;
                case '7':
                    sb.Append("семьсот ");
                    break;
                case '8':
                    sb.Append("восемьсот ");
                    break;
                case '9':
                    sb.Append("девятьсот ");
                    break;
            }
            if (number[1] == '1')
            {
                switch (number[2])
                {
                    case '0':
                        sb.Append("десять");
                        break;
                    case '1':
                        sb.Append("одиннадцать");
                        break;
                    case '2':
                        sb.Append("двенадцать");
                        break;
                    case '3':
                        sb.Append("трниадцать");
                        break;
                    case '4':
                        sb.Append("четынадцать");
                        break;
                    case '5':
                        sb.Append("пятнадцать");
                        break;
                    case '6':
                        sb.Append("шестнадцать");
                        break;
                    case '7':
                        sb.Append("семнадцать");
                        break;
                    case '8':
                        sb.Append("восемнадцать");
                        break;
                    case '9':
                        sb.Append("девятнадцать");
                        break;
                }
                return sb.ToString();
            }
            else
            {
                switch (number[1])
                {
                    case '2':
                        sb.Append("двадцать ");
                        break;
                    case '3':
                        sb.Append("тридцать ");
                        break;
                    case '4':
                        sb.Append("сорок ");
                        break;
                    case '5':
                        sb.Append("пятьдесят ");
                        break;
                    case '6':
                        sb.Append("шестьдесят ");
                        break;
                    case '7':
                        sb.Append("семьдесят ");
                        break;
                    case '8':
                        sb.Append("восемьдесят ");
                        break;
                    case '9':
                        sb.Append("девяносто ");
                        break;
                }
            }
            switch (number[2])
            {
                case '0':
                    break;
                case '1':
                    sb.Append("один");
                    break;
                case '2':
                    sb.Append("два");
                    break;
                case '3':
                    sb.Append("три");
                    break;
                case '4':
                    sb.Append("четыре");
                    break;
                case '5':
                    sb.Append("пять");
                    break;
                case '6':
                    sb.Append("шесть");
                    break;
                case '7':
                    sb.Append("семь");
                    break;
                case '8':
                    sb.Append("восемь");
                    break;
                case '9':
                    sb.Append("девять");
                    break;
            }
            return sb.ToString();
        }
        private static string NumberUpTo999ToString(string input, bool isChangedEnding)
        {
            var sb = new StringBuilder();
            string number = "";
            if (input.Length % 3 != 0)
            {
                for (int i = 0; i < 3 - (input.Length % 3); i++)
                {
                    number += "0";
                }
            }
            number += input;
            try
            {
                if (Convert.ToInt32(number) > 999)
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            switch (number[0])
            {
                case '0':
                    break;
                case '1':
                    sb.Append("сто ");
                    break;
                case '2':
                    sb.Append("двести ");
                    break;
                case '3':
                    sb.Append("триста ");
                    break;
                case '4':
                    sb.Append("четыреста ");
                    break;
                case '5':
                    sb.Append("пятьсот ");
                    break;
                case '6':
                    sb.Append("шестьсот ");
                    break;
                case '7':
                    sb.Append("семьсот ");
                    break;
                case '8':
                    sb.Append("восемьсот ");
                    break;
                case '9':
                    sb.Append("девятьсот ");
                    break;
            }
            if (number[1] == '1')
            {
                switch (number[2])
                {
                    case '0':
                        sb.Append("десять");
                        break;
                    case '1':
                        sb.Append("одиннадцать");
                        break;
                    case '2':
                        sb.Append("двенадцать");
                        break;
                    case '3':
                        sb.Append("тринадцать");
                        break;
                    case '4':
                        sb.Append("четырнадцать");
                        break;
                    case '5':
                        sb.Append("пятнадцать");
                        break;
                    case '6':
                        sb.Append("шестнадцать");
                        break;
                    case '7':
                        sb.Append("семнадцать");
                        break;
                    case '8':
                        sb.Append("восемнадцать");
                        break;
                    case '9':
                        sb.Append("девятнадцать");
                        break;
                }
                return sb.ToString();
            }
            else
            {
                switch (number[1])
                {
                    case '2':
                        sb.Append("двадцать ");
                        break;
                    case '3':
                        sb.Append("тридцать ");
                        break;
                    case '4':
                        sb.Append("сорок ");
                        break;
                    case '5':
                        sb.Append("пятьдесят ");
                        break;
                    case '6':
                        sb.Append("шестьдесят ");
                        break;
                    case '7':
                        sb.Append("семьдесят ");
                        break;
                    case '8':
                        sb.Append("восемьдесят ");
                        break;
                    case '9':
                        sb.Append("девяносто ");
                        break;
                }
            }
            if (!isChangedEnding)
            {
                switch (number[2])
                {
                    case '0':
                        break;
                    case '1':
                        sb.Append("один");
                        break;
                    case '2':
                        sb.Append("два");
                        break;
                    case '3':
                        sb.Append("три");
                        break;
                    case '4':
                        sb.Append("четыре");
                        break;
                    case '5':
                        sb.Append("пять");
                        break;
                    case '6':
                        sb.Append("шесть");
                        break;
                    case '7':
                        sb.Append("семь");
                        break;
                    case '8':
                        sb.Append("восемь");
                        break;
                    case '9':
                        sb.Append("девять");
                        break;
                }
            }
            else
            {
                switch (number[2])
                {
                    case '0':
                        break;
                    case '1':
                        sb.Append("одна");
                        break;
                    case '2':
                        sb.Append("две");
                        break;
                    case '3':
                        sb.Append("три");
                        break;
                    case '4':
                        sb.Append("четыре");
                        break;
                    case '5':
                        sb.Append("пять");
                        break;
                    case '6':
                        sb.Append("шесть");
                        break;
                    case '7':
                        sb.Append("семь");
                        break;
                    case '8':
                        sb.Append("восемь");
                        break;
                    case '9':
                        sb.Append("девять");
                        break;
                }
            }
            return sb.ToString().Trim();
        }
        private static bool CheckEndingByCategory(int input)
        {
            if (input == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static int CheckEndingByNumber(string input)
        {
            if (input[1] == '1')
            {
                return 2;
            }
            int number = Convert.ToInt32(input[2].ToString());

            if (number == 1)
            {
                return 0;
            }
            else if (number >= 2 && number <= 4)
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

    }
}
