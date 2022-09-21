using System;

namespace Vtitbid.ISP20.Romashov.Console.Objects
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth)
            : this(firstName, lastName)
        {
            DateOfBirth = dateOfBirth;
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth, DateTime dateOfDeath)
            : this(firstName, lastName, dateOfBirth)
        {
            DateOfDeath = dateOfDeath;
        }

        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private bool _isDead;
        private DateTime? _dateOfDeath;

        public string FirstName
        {
            get
            {
                if (_firstName == null)
                {
                    return "Unknown";
                }
                return _firstName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                {
                    _firstName = value.Trim();
                }
                else
                {
                    System.Console.Error.WriteLine($"\"{value}\" can`t be a new first name, changes not saved");
                }
            }
        }
        public string LastName
        {
            get
            {
                if (_lastName == null)
                {
                    return "Unknown";
                }
                return _lastName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value))
                {
                    _lastName = value.Trim();
                }
                else
                {
                    System.Console.Error.WriteLine($"\"{value}\" can`t be a new last name, changes not saved");
                }
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public int Age
        {
            get
            {
                var n = DateTime.Today;

                if (_dateOfBirth >= n || _dateOfBirth == new DateTime())
                {
                    return 0;
                }
                var age = n.Year - _dateOfBirth.Year;
                if (_dateOfBirth.Month > n.Month || (_dateOfBirth.Month == n.Month && _dateOfBirth.Day > n.Day))
                {
                    age--;
                }
                return age;
            }
        }
        public bool IsDead
        {
            get { return _isDead; }
            set
            {
                _isDead = value;
                if (value)
                {
                    _dateOfDeath = DateTime.Now.Date;
                }
                else
                {
                    _dateOfDeath = null;
                }
            }
        }
        public DateTime? DateOfDeath
        {
            get
            {
                if (_isDead)
                {
                    return _dateOfDeath;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _isDead = true;
                _dateOfDeath = value;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is Person)
            {
                return GetHashCode() == obj.GetHashCode();
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth, Age, IsDead, DateOfDeath);
        }
    }
}