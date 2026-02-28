using System;

namespace MathLibrary
{
    /// <summary>
    /// Основной класс математической библиотеки.
    /// Содержит методы для базовых арифметических операций и проверки чисел.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Складывает два числа.
        /// </summary>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Вычитает второе число из первого.
        /// </summary>
        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Умножает два числа.
        /// </summary>
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Делит первое число на второе.
        /// </summary>
        public static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Делитель не может быть равен нулю.");
            }
            return a / b;
        }

        /// <summary>
        /// Проверяет, является ли число простым.
        /// </summary>
        public static bool IsPrime(int number)
        {
            // Проверка на отрицательные числа, 0 и 1
            if (number <= 1)
                return false;
            
            // Проверка на четные числа (кроме 2)
            if (number == 2)
                return true;
            if (number % 2 == 0)
                return false;
            
            // Проверка делителей до квадратного корня из числа
            int boundary = (int)Math.Floor(Math.Sqrt(number));
            
            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                    return false;
            }
            
            return true;
        }

        /// <summary>
        /// Возводит число в степень.
        /// </summary>
        public static double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }

        /// <summary>
        /// Вычисляет факториал числа.
        /// </summary>
        public static long Factorial(int n)
        {
            // Проверка на отрицательное число
            if (n < 0)
            {
                throw new ArgumentException("Факториал отрицательного числа не определен.");
            }
            
            // Базовый случай
            if (n == 0 || n == 1)
                return 1;
            
            // Рекурсивное вычисление
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            
            return result;
        }

        /// <summary>
        /// Решает квадратное уравнение ax² + bx + c = 0.
        /// </summary>
        /// <returns>true, если уравнение имеет действительные корни, иначе false</returns>
        public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = null;
            x2 = null;
            
            // Проверка на линейное уравнение (a = 0)
            if (a == 0)
            {
                if (b == 0)
                {
                    // Если a=0 и b=0, то либо нет решений, либо бесконечно много
                    return c == 0; // Если c=0, то бесконечно много решений
                }
                
                // Линейное уравнение bx + c = 0
                x1 = -c / b;
                return true;
            }
            
            // Вычисление дискриминанта
            double discriminant = b * b - 4 * a * c;
            
            if (discriminant < 0)
            {
                return false; // Действительных корней нет
            }
            else if (Math.Abs(discriminant) < 1e-10) // Дискриминант близок к нулю
            {
                x1 = -b / (2 * a);
                return true;
            }
            else
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return true;
            }
        }
    }
}