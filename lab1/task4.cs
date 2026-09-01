using System;

namespace lab1
{
        internal static class Task4
        {
            public static void Run()
            {
                bool backToMenu = false;
                while (!backToMenu)
                {
                    Console.WriteLine("\n=== Вычисление площадей геометрических фигур ===");
                    Console.WriteLine("1. Прямоугольник");
                    Console.WriteLine("2. Треугольник");
                    Console.WriteLine("3. Трапеция");
                    Console.WriteLine("4. Круг");
                    Console.WriteLine("5. Сектор круга");
                    Console.WriteLine("0. Назад");
                    Console.Write("Выберите фигуру: ");
                    string Choice = Console.ReadLine();

                    try
                    {
                        double S = 0;
                        switch (Choice)
                        {
                            case "1":
                                Console.Write("Введите сторону a: ");
                                double rectA = double.Parse(Console.ReadLine());
                                Console.Write("Введите сторону b: ");
                                double rectB = double.Parse(Console.ReadLine());
                                S = RectangleArea(rectA, rectB);
                                Console.WriteLine($"\nПлощадь прямоугольника: S = {S:F4}");
                                break;

                            case "2":
                                Console.Write("Введите основание a: ");
                                double triA = double.Parse(Console.ReadLine());
                                Console.Write("Введите высоту h: ");
                                double triH = double.Parse(Console.ReadLine());
                                S = TriangleArea(triA, triH);
                                Console.WriteLine($"\nПлощадь треугольника: S = {S:F4}");
                                break;

                            case "3":
                                Console.Write("Введите основание a: ");
                                double trapA = double.Parse(Console.ReadLine());
                                Console.Write("Введите основание b: ");
                                double trapB = double.Parse(Console.ReadLine());
                                Console.Write("Введите высоту h: ");
                                double trapH = double.Parse(Console.ReadLine());
                                S = TrapezoidArea(trapA, trapB, trapH);
                                Console.WriteLine($"\nПлощадь трапеции: S = {S:F4}");
                                break;

                            case "4":
                                Console.Write("Введите радиус R: ");
                                double circleR = double.Parse(Console.ReadLine());
                                S = CircleArea(circleR);
                                Console.WriteLine($"\nПлощадь круга: S = {S:F4}");
                                break;

                            case "5":
                                Console.Write("Введите радиус R: ");
                                double sectorR = double.Parse(Console.ReadLine());
                                Console.Write("Введите угол a (градусы, от 0 до 360): ");
                                double sectorA = double.Parse(Console.ReadLine());
                                S = SectorArea(sectorR, sectorA);
                                Console.WriteLine($"\nПлощадь сектора: S = {S:F4}");
                                break;

                            case "0":
                                backToMenu = true;
                                break;

                            default:
                                Console.WriteLine("Неверный выбор! Попробуйте снова.");
                                break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ошибка! Введите корректное числовое значение!");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
                    }
                    Console.WriteLine();
                }
            }

            private static double RectangleArea(double a, double b)
            {
                if (a <= 0 || b <= 0)
                    throw new ArgumentException("Стороны прямоугольника должны быть положительными!");
                return a * b;
            }

            private static double TriangleArea(double a, double h)
            {
                if (a <= 0 || h <= 0)
                    throw new ArgumentException("Основание и высота треугольника должны быть положительными!");
                return a * (h / 2.0);
            }

            private static double TrapezoidArea(double a, double b, double h)
            {
                if (a <= 0 || b <= 0 || h <= 0)
                    throw new ArgumentException("Основания и высота трапеции должны быть положительными!");
                return (a + b) * (h / 2.0);
            }

            private static double CircleArea(double r)
            {
                if (r <= 0)
                    throw new ArgumentException("Радиус круга должен быть положительным!");
                return Math.PI * r * r;
            }

            private static double SectorArea(double r, double a)
            {
                if (r <= 0)
                    throw new ArgumentException("Радиус сектора должен быть положительным!");
                if (a <= 0 || a >= 360)
                    throw new ArgumentException("Угол сектора должен быть в диапазоне (0, 360)!");
                return Math.PI * r * r * (a / 360.0);
            }
        }
}

