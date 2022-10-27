using System;
using System.Text;

namespace Vtitbid.ISP20.Romashov.Console.Cyphers
{
    static class Vigenere
    {
        private const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Encrypt(string input, string key)
        {
            key = key.ToUpper();
            var result = new StringBuilder();
            var keyIndex = 0;
            var inputIndex = 0;
            var counter = 0;
            var isUpper = true;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {

                }
                counter = counter % key.Length;
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (key[counter] == alphabet[j] || key[counter] == alphabet.ToLower()[j])
                    {
                        keyIndex = j;
                    }
                }
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (input[i] == alphabet[j])
                    {
                        inputIndex = j;
                        isUpper = true;
                    }
                    else if (input[i] == alphabet.ToLower()[j])
                    {
                        inputIndex = j;
                        isUpper = false;
                    }
                }
                if (isUpper)
                {
                    result.Append(alphabet[(inputIndex + keyIndex) % alphabet.Length]);
                }
                else
                {
                    result.Append(alphabet.ToLower()[(inputIndex + keyIndex) % alphabet.Length]);
                }
                counter++;
            }
            return result.ToString();
        }

    }
}
