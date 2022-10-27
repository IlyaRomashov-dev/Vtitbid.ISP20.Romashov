using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.ZodiacTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int numberOfPeople;
            do
            {
                Write("Введите количество людей: ");
                input = ReadLine();
            } while (!Int32.TryParse(input, out numberOfPeople));
            Person[] persons = new Person[numberOfPeople];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = ConsoleInteractive.CreatePerson();
            }

            Person[] sortedPersons = persons.OrderBy(ob => ob.Zodiac).ToArray();
            foreach (var person in sortedPersons)
            {
                WriteLine(person);
            }

        }
    }
}