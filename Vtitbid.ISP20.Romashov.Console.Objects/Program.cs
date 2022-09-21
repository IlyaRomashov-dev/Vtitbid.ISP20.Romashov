using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            var ilya = new Person("Ilya", "Romashov");
            var ilya2 = new Person("Ilya", "Romashov");
            WriteLine(ilya.Equals(ilya2));
        }

    }
}