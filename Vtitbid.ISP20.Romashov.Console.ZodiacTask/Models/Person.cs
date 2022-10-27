using System;

namespace Vtitbid.ISP20.Romashov.Console.ZodiacTask
{
    internal class Person
    {
        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public string Zodiac
        {
            get
            {
                return SetZodiac();
            }
        }
        public string YearSign
        {
            get
            {
                return SetYearSign();
            }
        }
        private string SetZodiac()
        {
            int month = DateOfBirth.Month;
            int day = DateOfBirth.Day;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                return "Овен";
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
            {
                return "Телец";
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
            {
                return "Близнецы";
            }
            else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
            {
                return "Рак";
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
            {
                return "Лев";
            }
            else if ((month == 8 && day >= 24) || (month == 9 && day <= 22))
            {
                return "Дева";
            }
            else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
            {
                return "Весы";
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
            {
                return "Скорпион";
            }
            else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
            {
                return "Стрелец";
            }
            else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
            {
                return "Козерог";
            }
            else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
            {
                return "Водолей";
            }
            else
            {
                return "Рыбы";
            }
        }
        private string SetYearSign()
        {
            int year = DateOfBirth.Year;
            switch ((year + 8) % 12)
            {
                case 0: return "Крыса";
                case 1: return "Бык";
                case 2: return "Тигр";
                case 3: return "Заяц";
                case 4: return "Дракон";
                case 5: return "Змея";
                case 6: return "Конь";
                case 7: return "Овца";
                case 8: return "Обезьяна";
                case 9: return "Петух";
                case 10: return "Собака";
                default: return "Кабан";
            }
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Знак зодиака: {Zodiac}, Знак года: {YearSign}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   FirstName == person.FirstName &&
                   LastName == person.LastName &&
                   DateOfBirth == person.DateOfBirth &&
                   Zodiac == person.Zodiac;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth, Zodiac);
        }

    }
}
