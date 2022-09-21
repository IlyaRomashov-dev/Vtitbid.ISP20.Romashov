using System;

namespace Vtitbid.ISP20.Romashov.Console.Objects
{
    public class UniversityMember : Person
    {
        public UniversityMember(string firstName, string lastName)
        : base(firstName, lastName)
        {

        }
        private int[] _status;
        public string Status
        {
            get
            {
                string result = string.Empty;
                int[] newStatus = new int[0];
                Array.Sort(_status);
                int length = 0;
                foreach (var a in Enum.GetValues(typeof(UniversityMembers)))
                {
                    length++;
                }
                for (int i = 0; i < length; i++)
                {
                    if (_status.Contains(i))
                    {
                        newStatus.Append(i);
                    }
                }
                _status = newStatus;
                for (int i = 0; i < _status.Length; i++)
                {
                    result += ((UniversityMembers)i).ToString() + " ";
                }
                return result.TrimEnd(' ');
            }
            set
            {
                int length = 0;
                foreach (var a in Enum.GetValues(typeof(UniversityMembers)))
                {
                    length++;
                }
                for (int i = 0; i < length; i++)
                {
                    if (value.ToUpper() == ((UniversityMembers)i).ToString().ToUpper())
                    {
                        _status.Append(i);
                        System.Console.WriteLine($"{FirstName} {LastName} добавлен статус {value}");
                        break;
                    }
                    System.Console.WriteLine($"Введённый статус \"{value}\"не является одним из существующих");
                }
            }

        }

    }
}