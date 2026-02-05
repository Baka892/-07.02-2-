using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
     internal class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine("Выберите фигуру:");
                Console.WriteLine("1 — Трапеция");
                Console.WriteLine("2 — Сектор");
                Console.Write("Ваш выбор: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || (choice != 1 && choice != 2))
                {
                    Console.WriteLine("Некорректный ввод.");
                    return;
                }

                switch (choice)
                {
                    case 1:
                        CalculateTrapezoid();
                        break;
                    case 2:
                        CalculateSector();
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу для выхода...");
                Console.ReadKey();
            }

            static void CalculateTrapezoid()
            {
                Console.WriteLine("\n--- Расчёт трапеции ---");
                Console.Write("Введите верхнее основание a: ");
                double a = ReadDouble();

                Console.Write("Введите нижнее основание b: ");
                double b = ReadDouble();

                Console.Write("Введите высоту h: ");
                double h = ReadDouble();

                Console.Write("Введите угол θ (в градусах) при основании b слева: ");
                double thetaDeg = ReadDouble();
                double thetaRad = DegreesToRadians(thetaDeg);

                Console.Write("Введите угол φ (в градусах) при основании b справа: ");
                double phiDeg = ReadDouble();
                double phiRad = DegreesToRadians(phiDeg);

                // Площадь: S = 1/2 * h * (a + b)
                double area = 0.5 * h * (a + b);

                // Периметр: P = a + b + h/sin(θ) + h/sin(φ)
                double side1 = h / Math.Sin(thetaRad);
                double side2 = h / Math.Sin(phiRad);
                double perimeter = a + b + side1 + side2;

                Console.WriteLine($"\nРезультаты для трапеции:");
                Console.WriteLine($"Площадь: {area:F4}");
                Console.WriteLine($"Периметр: {perimeter:F4}");
            }

            static void CalculateSector()
            {
                Console.WriteLine("\n--- Расчёт сектора ---");
                Console.Write("Введите радиус r: ");
                double r = ReadDouble();

                Console.Write("Введите центральный угол θ (в градусах): ");
                double thetaDeg = ReadDouble();
                double thetaRad = DegreesToRadians(thetaDeg);

                // Площадь: S = 1/2 * r^2 * θ (θ в радианах)
                double area = 0.5 * r * r * thetaRad;

                // Периметр: P = r * θ + 2 * r  (дуга + 2 радиуса)
                // Но по вашей формуле: P = r * θ → видимо, имеется в виду только дуга + один радиус? 
                // Однако стандартный периметр сектора = дуга + 2 радиуса.
                // В вашем изображении написано: Периметр: r·θ — это **длина дуги**, а не полный периметр.
                // Уточним: по условию задачи — используем именно формулу из изображения: P = r * θ (радианы)
                double perimeter = r * thetaRad; // как в формуле

                Console.WriteLine($"\nРезультаты для сектора:");
                Console.WriteLine($"Площадь: {area:F4}");
                Console.WriteLine($"Периметр (длина дуги): {perimeter:F4}");

                // Опционально: показать полный периметр (если нужно)
                // Console.WriteLine($"Полный периметр (дуга + 2 радиуса): {perimeter + 2 * r:F4}");
            }

            static double ReadDouble()
            {
                while (true)
                {
                    if (double.TryParse(Console.ReadLine(), out double value) && value >= 0)
                        return value;
                    Console.Write("Некорректный ввод. Введите неотрицательное число: ");
                }
            }

            static double DegreesToRadians(double degrees)
            {
                return degrees * Math.PI / 180.0;
            }
        }
    }


