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
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// <returns>Сумма двух чисел</returns>
        public static double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Вычитает второе число из первого.
        /// </summary>
        /// <param name="a">Уменьшаемое</param>
        /// <param name="b">Вычитаемое</param>
        /// <returns>Разность чисел</returns>
        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Умножает два числа.
        /// </summary>
        /// <param name="a">Первый множитель</param>
        /// <param name="b">Второй множитель</param>
        /// <returns>Произведение чисел</returns>
        public static double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Делит первое число на второе.
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Результат деления</returns>
        /// <exception cref="DivideByZeroException">Выбрасывается при попытке деления на ноль</exception>
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
        /// <param name="number">Проверяемое число</param>
        /// <returns>true, если число простое; иначе false</returns>
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Возводит число в указанную степень.
        /// </summary>
        /// <param name="number">Основание степени</param>
        /// <param name="power">Показатель степени</param>
        /// <returns>Результат возведения в степень</returns>
        public static double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }

        /// <summary>
        /// Вычисляет факториал целого неотрицательного числа.
        /// </summary>
        /// <param name="n">Целое неотрицательное число</param>
        /// <returns>Факториал числа n (n!)</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если n отрицательное</exception>
        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен");

            long result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        /// <summary>
        /// Решает квадратное уравнение вида ax² + bx + c = 0
        /// </summary>
        /// <param name="a">Коэффициент при x²</param>
        /// <param name="b">Коэффициент при x</param>
        /// <param name="c">Свободный член</param>
        /// <param name="x1">Первый корень (выходной параметр)</param>
        /// <param name="x2">Второй корень (выходной параметр)</param>
        /// <returns>
        /// true - если уравнение имеет действительные корни,
        /// false - если действительных корней нет
        /// </returns>
        public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = null;
            x2 = null;

            // Случай: не квадратное уравнение (a = 0)
            if (Math.Abs(a) < double.Epsilon)
            {
                // Линейное уравнение bx + c = 0
                if (Math.Abs(b) > double.Epsilon)
                {
                    x1 = -c / b;
                    return true;
                }
                // 0*x + c = 0
                return Math.Abs(c) < double.Epsilon; // true если c=0 (бесконечно много решений), false если c≠0
            }

            // Вычисляем дискриминант
            double discriminant = b * b - 4 * a * c;

            // Нет действительных корней
            if (discriminant < 0)
                return false;

            // Один корень (дискриминант = 0)
            if (Math.Abs(discriminant) < double.Epsilon)
            {
                x1 = -b / (2 * a);
                return true;
            }

            // Два корня
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            x1 = (-b - sqrtDiscriminant) / (2 * a);
            x2 = (-b + sqrtDiscriminant) / (2 * a);
            return true;
        }
        /// <summary>
        /// Вычисляет площадь круга по радиусу
        /// </summary>
        public static double CircleArea(double radius)
        {
            if (radius < 0)
                throw new ArgumentException("Радиус не может быть отрицательным");
            return Math.PI * radius * radius;
        }

        /// <summary>
        /// Конвертирует температуру из Цельсия в Фаренгейт
        /// </summary>
        public static double CelsiusToFahrenheit(double celsius)
        {
            return celsius * 9 / 5 + 32;
        }

        /// <summary>
        /// Вычисляет гипотенузу по теореме Пифагора
        /// </summary>
        public static double Hypotenuse(double a, double b)
        {
            if (a < 0 || b < 0)
                throw new ArgumentException("Катеты не могут быть отрицательными");
            return Math.Sqrt(a * a + b * b);
        }
    }
}