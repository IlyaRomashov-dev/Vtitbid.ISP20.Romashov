using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.Cyphers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine(Vigenere.Encrypt("IlyaRomashov", "Alina"));

        }
    }
}