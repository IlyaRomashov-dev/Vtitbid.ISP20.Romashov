using System;
using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.ZodiacTask
{
    class ConsoleInteractive
    {
        public static Person CreatePerson()
        {
            bool isCorrectly;
            string firstName = "";
            string lastName = "";
            DateTime date = DateTime.Now;
            do
            {
                isCorrectly = false;
                try
                {
                    Write("Введите имя: ");
                    firstName = ReadLine();
                    Write("Введите фамилию: ");
                    lastName = ReadLine();
                    Write("Введите дату рождения(в виде DD.MM.YYYY): ");
                    date = Convert.ToDateTime(ReadLine());
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
            return new Person(firstName, lastName, date);
        }


    }
}
