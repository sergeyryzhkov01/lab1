using System;

namespace lab1
{
    internal class Program
    {
        struct Motorcycle
        {
            public string Brand;
            public string Model;
            public int Year;
            public int MaxSpeed;
            public double Price;

            public Motorcycle(string brand, string model, int year, int maxSpeed, double price)
            {
                Brand = brand; Model = model; Year = year; MaxSpeed = maxSpeed; Price = price;
            }
            public void Display()
            {
                Console.WriteLine("\nДанные о мотоцикле:");
                Console.WriteLine($"Марка: {Brand}");
                Console.WriteLine($"Модель: {Model}");
                Console.WriteLine($"Год выпуска: {Year}");
                Console.WriteLine($"Максимальная скорость: {MaxSpeed} км/ч");
                Console.WriteLine($"Цена: {Price} руб.");
            }
        }
        static void Main(string[] args)
        {
            bool exit = false;
            string choice;

            while (!exit)
            {
                Console.WriteLine("===Лабораторная работа №1===");
                Console.WriteLine("1. Даны x, y, z. Вычислить a, b, если...");
                Console.WriteLine("2. Вычислить время падения тела с высоты H с начальной скоростью V.");
                Console.WriteLine("3. Определить, имеет ли квадратное уравнение с коэффициентами a, b и c решение.");
                Console.WriteLine("4. Составить программу вычисления площадей различных геометрических фигур");
                Console.WriteLine("5. Создать структуру с методом отображения данных");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Введите x: "); double x = double.Parse(Console.ReadLine());
                            Console.WriteLine("Введите y: "); double y = double.Parse(Console.ReadLine());
                            Console.WriteLine("Введите z: "); double z = double.Parse(Console.ReadLine());

                            double denomIn = y + x * x;
                            if (denomIn == 0)
                                throw new DivideByZeroException("Знаменатель (y+x^2) равен нулю!");

                            double denomAbs = Math.Abs((x * x) / denomIn);

                            double denom = y * y + denomAbs;
                            if (denom == 0)
                                throw new DivideByZeroException("Знаменатель y^2 + |...| равен нулю!");

                            double fraction = x / denom;

                            double a = y + fraction;

                            double tg = Math.Tan(z / 2);
                            double b = Math.Pow(1 + tg * tg, 2);

                            Console.WriteLine();
                            Console.WriteLine($"a = {a:F4}");
                            Console.WriteLine($"b = {b:F4}");
                        }
                        catch (DivideByZeroException ex)
                        {
                            Console.WriteLine($"Ошибка вычисления: {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Произошла ошибка: {ex.Message}");
                        }
                        Console.WriteLine();
                        break;

                    case "2":
                        const double g = 9.8;
                        try
                        {
                            Console.WriteLine("Введите высоту H (м): "); double H = Double.Parse(Console.ReadLine());
                            if (H <= 0)
                                throw new ArgumentException("Высота не может быть отрицательной или равняться нулю!");
                            Console.WriteLine("Введите начальную скорость V (м/c): "); double V = Double.Parse(Console.ReadLine());
                            if (V <= 0)
                                throw new ArgumentException("Скорость не может быть отрицательной или равняться нулю!");

                            double discriminant = V * V + 2 * g * H;
                            if (discriminant < 0)
                                throw new ArgumentException("D < 0, под корнем отрицательное число!");

                            double t = (-V + Math.Sqrt(discriminant)) / g;
                            if (t < 0)
                                throw new ArgumentException("Ошибка! Время не может быть отрицательным");

                            Console.WriteLine($"Время падения: {t:F4}");
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
                        break;

                    case "3":
                        try
                        {
                            Console.WriteLine("Введите a: "); double a = Double.Parse(Console.ReadLine());
                            if (a == 0)
                                throw new ArgumentException("a не может быть равен 0 - это не квадратное уравнение!");
                            Console.WriteLine("Введите b: "); double b = Double.Parse(Console.ReadLine());
                            Console.WriteLine("Введите c: "); double c = Double.Parse(Console.ReadLine());

                            double D = b * b - 4 * a * c;
                            if (D < 0) throw new ArgumentException("D < 0, действительных корней нет!");

                            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                            double x2 = (-b - Math.Sqrt(D)) / (2 * a);

                            Console.WriteLine("Квадратное уравнение имеет решение! x1 = " + x1 + ", x2 = " + x2);
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Введите корректные числовые данные!");
                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка! {ex.Message}");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Непредвиденная ошибка! {ex.Message}");
                        }
                        Console.WriteLine();
                        break;

                    case "4":
                        Task4.Run();
                        break;

                    case "5":
                        try
                        {
                            Motorcycle moto = new Motorcycle();
                            Console.Write("Введите цену мотоцикла: "); moto.Price = Double.Parse(Console.ReadLine());
                            if (moto.Price < 0) throw new ArgumentException("Цена не может быть отрицательной!");

                            Console.Write("Введите год выпуска мотоцикла: "); moto.Year = int.Parse(Console.ReadLine());
                            if (moto.Year > 2026 || moto.Year < 1890) throw new ArgumentException("Некорректный год выпуска!");

                            Console.Write("Введите бренд мотоцикла: "); moto.Brand = Console.ReadLine();

                            Console.Write("Введите макс. скорость мотоцикла: "); moto.MaxSpeed = int.Parse(Console.ReadLine());
                            if (moto.MaxSpeed < 0) throw new ArgumentException("Скорость не может быть отрицательной!");

                            Console.Write("Введите модель мотоцикла: "); moto.Model = Console.ReadLine();

                            moto.Display();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка! Введен некорректный формат данных!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка! {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Возникла непредвиденная ошибка! {ex.Message}");
                        }
                        Console.WriteLine();
                        break;
                    case "0":
                            Console.WriteLine("Выход из программы...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка в выборе пункта меню");
                        break;
                }
            }
        }
    }
}
