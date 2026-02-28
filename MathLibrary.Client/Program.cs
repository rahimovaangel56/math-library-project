using System;
using MathLibrary;

// Тестовое приложение для демонстрации всех возможностей MathLibrary
namespace MathLibrary.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   ДЕМОНСТРАЦИЯ РАБОТЫ MathLibrary.dll");
            Console.WriteLine("========================================\n");

            // Демонстрация базовых арифметических операций
            DemonstrateBasicArithmetic();
            
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            
            // Демонстрация проверки на простоту
            DemonstratePrimeNumbers();
            
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            
            // Демонстрация возведения в степень
            DemonstratePower();
            
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            
            // Демонстрация вычисления факториала
            DemonstrateFactorial();
            
            Console.WriteLine("\n" + new string('-', 40) + "\n");
            
            // Демонстрация решения квадратных уравнений
            DemonstrateQuadraticEquations();
            
            Console.WriteLine("\n========================================");
            Console.WriteLine("   РАБОТА ПРОГРАММЫ ЗАВЕРШЕНА");
            Console.WriteLine("========================================");
        }

        static void DemonstrateBasicArithmetic()
        {
            Console.WriteLine("--- БАЗОВЫЕ АРИФМЕТИЧЕСКИЕ ОПЕРАЦИИ ---");
            
            double x = 10, y = 4;
            Console.WriteLine($"Числа: x = {x}, y = {y}\n");
            
            Console.WriteLine($"Сложение: {x} + {y} = {Calculator.Add(x, y)}");
            Console.WriteLine($"Вычитание: {x} - {y} = {Calculator.Subtract(x, y)}");
            Console.WriteLine($"Умножение: {x} * {y} = {Calculator.Multiply(x, y)}");
            
            try
            {
                Console.WriteLine($"Деление: {x} / {y} = {Calculator.Divide(x, y)}");
                Console.WriteLine($"Деление на ноль: {x} / 0 = {Calculator.Divide(x, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Деление на ноль: ОШИБКА - {ex.Message}");
            }
        }

        static void DemonstratePrimeNumbers()
        {
            Console.WriteLine("--- ПРОВЕРКА ЧИСЕЛ НА ПРОСТОТУ ---");
            
            int[] testNumbers = { 1, 2, 3, 4, 17, 19, 25, 97, 100 };
            
            foreach (int num in testNumbers)
            {
                bool isPrime = Calculator.IsPrime(num);
                Console.WriteLine($"Число {num,3}: {(isPrime ? "простое" : "составное")}");
            }
        }

        static void DemonstratePower()
        {
            Console.WriteLine("--- ВОЗВЕДЕНИЕ В СТЕПЕНЬ ---");
            
            var testCases = new (double number, double power)[]
            {
                (2, 3),
                (5, 2),
                (3, 4),
                (10, 0),
                (16, 0.5),
                (2, -1)
            };
            
            foreach (var test in testCases)
            {
                double result = Calculator.Power(test.number, test.power);
                Console.WriteLine($"{test.number}^{test.power} = {result}");
            }
        }

        static void DemonstrateFactorial()
        {
            Console.WriteLine("--- ВЫЧИСЛЕНИЕ ФАКТОРИАЛА ---");
            
            int[] testNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            foreach (int n in testNumbers)
            {
                try
                {
                    long fact = Calculator.Factorial(n);
                    Console.WriteLine($"{n}! = {fact,10}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"{n}! - ОШИБКА: {ex.Message}");
                }
            }
            
            // Проверка обработки ошибок
            try
            {
                Console.WriteLine("Попытка вычислить факториал -5:");
                Calculator.Factorial(-5);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  ОШИБКА: {ex.Message}");
            }
        }

        static void DemonstrateQuadraticEquations()
        {
            Console.WriteLine("--- РЕШЕНИЕ КВАДРАТНЫХ УРАВНЕНИЙ ---");
            
            var equations = new (double a, double b, double c, string description)[]
            {
                (1, -5, 6, "x² - 5x + 6 = 0 (два корня)"),
                (1, 2, 1, "x² + 2x + 1 = 0 (один корень)"),
                (2, -4, 2, "2x² - 4x + 2 = 0 (один корень)"),
                (1, 0, -4, "x² - 4 = 0 (два корня)"),
                (1, 0, 4, "x² + 4 = 0 (нет действительных корней)"),
                (0, 2, -6, "2x - 6 = 0 (линейное уравнение)"),
                (0, 0, 5, "5 = 0 (противоречие)"),
                (0, 0, 0, "0 = 0 (бесконечно много решений)")
            };
            
            foreach (var eq in equations)
            {
                Console.WriteLine($"\nУравнение: {eq.description}");
                
                bool hasRoots = Calculator.SolveQuadratic(eq.a, eq.b, eq.c, out double? x1, out double? x2);
                
                if (!hasRoots)
                {
                    Console.WriteLine("  Результат: Нет действительных корней");
                }
                else if (x1.HasValue && !x2.HasValue)
                {
                    Console.WriteLine($"  Результат: Один корень x = {x1.Value:F4}");
                }
                else if (x1.HasValue && x2.HasValue)
                {
                    Console.WriteLine($"  Результат: x₁ = {x1.Value:F4}, x₂ = {x2.Value:F4}");
                }
                else
                {
                    Console.WriteLine("  Результат: Бесконечно много решений");
                }
            }
        }
    }
}