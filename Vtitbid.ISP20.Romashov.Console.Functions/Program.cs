using static System.Console;

namespace Vtitbid.ISP20.Romashov.Console.Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(3, 4, 5);
            WriteLine(triangle);
            WriteLine($"Площадь: {triangle.FoundSquare()}");
            WriteLine($"{"A",-4}{"B",-4}{"C",-4}{"Проверка на",-20}{"Ожидаемый результат",-22}{"Полученный результат",-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Треугольник",-20}{"True",-22}{triangle.IsTriangle(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Разносторонний",-20}{"True",-22}{triangle.IsVersatile(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Равнобедренный",-20}{"False",-22}{triangle.IsIsosceles(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Равносторонний",-20}{"False",-22}{triangle.IsEquilateral(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Остроугольный",-20}{"False",-22}{triangle.IsSharpAngled(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Тупоугольный",-20}{"False",-22}{triangle.IsObtuseAngle(),-22}");
            WriteLine($"{triangle.SideA,-4}{triangle.SideB,-4}{triangle.SideC,-4}{"Прямоугольный",-20}{"True",-22}{triangle.IsRectangular(),-22}");
        }
    }
}