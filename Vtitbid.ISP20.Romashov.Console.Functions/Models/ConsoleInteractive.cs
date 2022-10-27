using System;
using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.Functions.Models
{
    class ConsoleInteractive
    {
        public static Person CreatePerson()
        {
            bool isCorrectly;
            string firstName = "";
            string lastName = "";
            int year = 9999;
            int month = 1;
            int day = 1;
            do
            {
                isCorrectly = false;
                try
                {
                    Write("Введите имя: ");
                    firstName = ReadLine();
                    Write("Введите фамилию: ");
                    lastName = ReadLine();
                    Write("Введите год рождения: ");
                    year = Convert.ToInt32(ReadLine());
                    Write("Введите месяц рождения: ");
                    month = Convert.ToInt32(ReadLine());
                    Write("Введите день рождения: ");
                    day = Convert.ToInt32(ReadLine());
                    isCorrectly = true;
                }
                catch
                {
                    Clear();
                    isCorrectly = false;
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Ошибка при вводе, попробуйте ещё раз");
                    ForegroundColor = ConsoleColor.Gray;
                    continue;
                }

            } while (!isCorrectly);
            return new Person(firstName, lastName, new DateTime(year, month, day));
        }
    }
}
