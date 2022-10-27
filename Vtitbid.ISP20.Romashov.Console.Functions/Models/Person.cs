using System;

namespace Vtitbid.ISP20.Romashov.Console.Functions.Models
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
        private string _zodiac;

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
                if (String.IsNullOrEmpty(_zodiac) || String.IsNullOrWhiteSpace(_zodiac))
                {
                    _zodiac = SetZodiac();
                }
                return _zodiac;
            }
            private set
            {
                _zodiac = SetZodiac();
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
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Zodiac}";
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
