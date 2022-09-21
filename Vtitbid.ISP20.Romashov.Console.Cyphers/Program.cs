using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.Cyphers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = 3.50;
            WriteLine(Convert.ToInt32(a));
            WriteLine(PseudoEncrypt.Encrypt("012345", 1));
            WriteLine(PseudoEncrypt.Encrypt("012345", 2));
            WriteLine(PseudoEncrypt.Encrypt("012345", 3));
            WriteLine(PseudoEncrypt.Decrypt(PseudoEncrypt.Encrypt("012345", 1), 1));
            WriteLine(PseudoEncrypt.Decrypt(PseudoEncrypt.Encrypt("012345", 2), 2));
            WriteLine(PseudoEncrypt.Decrypt(PseudoEncrypt.Encrypt("012345", 3), 3));

        }
    }
}