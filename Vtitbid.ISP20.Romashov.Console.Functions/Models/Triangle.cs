using System;

namespace Vtitbid.ISP20.Romashov.Console.Functions
{
    class Triangle
    {
        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
            CalculateAngles();
        }
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get
            {
                return _sideA;
            }
            set
            {
                if (value > 0)
                {
                    _sideA = value;
                }
                else
                {
                    _sideA = 0;
                }
                CalculateAngles();
            }
        }
        public double SideB
        {
            get
            {
                return _sideB;
            }
            set
            {
                if (value > 0)
                {
                    _sideB = value;
                }
                else
                {
                    _sideB = 0;
                }
                CalculateAngles();
            }
        }
        public double SideC
        {
            get
            {
                return _sideC;
            }
            set
            {
                if (value > 0)
                {
                    _sideC = value;
                }
                else
                {
                    _sideC = 0;
                }
                CalculateAngles();
            }
        }

        public double AngleA { get; private set; }
        public double AngleB { get; private set; }
        public double AngleC { get; private set; }

        public bool IsTriangle()
        {
            if (SideA <= 0 || SideB <= 0 || SideC <= 0)
            {
                return false;
            }
            else if (SideA + SideB < SideC || SideA + SideC < SideB || SideB + SideC < SideA)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsVersatile()  //разносторонний
        {
            if (!IsTriangle())
            {
                return false;
            }
            if (SideA != SideB && SideA != SideC && SideB != SideC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsIsosceles() //равнобедренный 
        {
            if (!IsTriangle())
            {
                return false;
            }
            if ((SideA == SideB && SideA != SideC) || (SideA == SideC && SideA != SideB) || (SideB == SideC && SideB != SideA))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsEquilateral() //равносторонний 
        {
            if (!IsTriangle())
            {
                return false;
            }
            if (SideA == SideB && SideB == SideC)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsSharpAngled() //остроугольный
        {
            if (!IsTriangle())
            {
                return false;
            }
            CalculateAngles();
            if (AngleA < 90 && AngleB < 90 && AngleC < 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsObtuseAngle() //тупоугольный 
        {
            if (!IsTriangle())
            {
                return false;
            }
            CalculateAngles();
            if (AngleA > 90 || AngleB > 90 || AngleC > 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsRectangular() //прямоугольный
        {
            if (!IsTriangle())
            {
                return false;
            }
            CalculateAngles();
            if (AngleA == 90 || AngleB == 90 || AngleC == 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double FoundSquare()
        {
            if (!IsTriangle())
            {
                return 0;
            }
            double result = 0;
            double P = (SideA + SideB + SideC) / 2;
            result = Math.Sqrt(P * (P - SideA) * (P - SideB) * (P - SideC));
            return result;

        }
        private void CalculateAngles()
        {
            if (!IsTriangle())
            {
                AngleA = 0;
                AngleB = 0;
                AngleC = 0;
                return;
            }
            double angleA = AngleA;
            double angleB = AngleB;
            double angleC = AngleC;
            angleA = Math.Acos((Math.Pow(SideA, 2) + Math.Pow(SideC, 2) - Math.Pow(SideB, 2)) / (2 * SideA * SideC));
            angleB = Math.Acos((Math.Pow(SideA, 2) + Math.Pow(SideB, 2) - Math.Pow(SideC, 2)) / (2 * SideA * SideB));
            angleC = Math.Acos((Math.Pow(SideB, 2) + Math.Pow(SideC, 2) - Math.Pow(SideA, 2)) / (2 * SideC * SideB));
            AngleA = Math.Round(angleA * (180 / Math.PI), 3);
            AngleB = Math.Round(angleB * (180 / Math.PI), 3);
            AngleC = Math.Round(angleC * (180 / Math.PI), 3);
        }
        // override System.Object methods
        public override string ToString()
        {
            CalculateAngles();
            string result = string.Empty;
            result += $"Сторона A: {SideA} Сторона B: {SideB} Сторона C: {SideC}";
            result += $"\nУгол A: {AngleA} Угол B: {AngleB} Угол C: {AngleC}";
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(AngleA, AngleC, AngleC, SideA, SideB, SideC);
        }
        public override bool Equals(object? obj)
        {
            if (obj is Triangle)
            {
                return obj.GetHashCode() == GetHashCode();
            }
            else
            {
                return false;
            }
        }
        //static methods
        public static bool IsTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }
            else if (a + b < c || a + c < b || b + c < a)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsVersatile(double a, double b, double c)  //разносторонний
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            if (a != b && a != c && b != c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsIsosceles(double a, double b, double c) //равнобедренный 
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            if ((a == b && a != c) || (a == c && a != b) || (b == c && b != a))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsEquilateral(double a, double b, double c) //равносторонний 
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            if (a == b && b == c)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsSharpAngled(double a, double b, double c) //остроугольный
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            double angleA;
            double angleB;
            double angleC;
            CalculateAngles(a, b, c, out angleA, out angleB, out angleC);
            if (angleA < 90 && angleB < 90 && angleC < 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsObtuseAngle(double a, double b, double c) //тупоугольный 
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            double angleA;
            double angleB;
            double angleC;
            CalculateAngles(a, b, c, out angleA, out angleB, out angleC);
            if (angleA > 90 || angleB > 90 || angleC > 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsRectangular(double a, double b, double c) //прямоугольный
        {
            if (!IsTriangle(a, b, c))
            {
                return false;
            }
            double angleA;
            double angleB;
            double angleC;
            CalculateAngles(a, b, c, out angleA, out angleB, out angleC);
            if (angleA == 90 || angleB == 90 || angleC == 90)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double FoundSquare(double a, double b, double c)
        {
            if (!IsTriangle(a, b, c))
            {
                return 0;
            }
            double result = 0;
            double P = (a + b + c) / 2;
            result = Math.Sqrt(P * (P - a) * (P - b) * (P - c));
            return result;

        }
        public static void CalculateAngles(double a, double b, double c, out double angleA, out double angleB, out double angleC)
        {
            if (!IsTriangle(a, b, c))
            {
                angleA = 0;
                angleB = 0;
                angleC = 0;
                return;
            }
            angleA = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));   // arccos(a^2 + c^2 - b^2) / (2ac)
            angleB = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b));   // arccos(a^2 + b^2 - c^2) / (2ab)
            angleC = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * c * b));   // arccos(b^2 + c^2 - a^2) / (2cb)
            angleA = Math.Round(angleA * (180 / Math.PI), 3);       // Перевод из радиан в градусы
            angleB = Math.Round(angleB * (180 / Math.PI), 3);       // Перевод из радиан в градусы
            angleC = Math.Round(angleC * (180 / Math.PI), 3);       // Перевод из радиан в градусы
        }

    }

}
