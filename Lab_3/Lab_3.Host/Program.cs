using System;
using System.Linq;
using Lab_3.Domain;

namespace Lab_3.Host
{
    class Program
    {
        private static string _stringExpression = "10 / 5 = 2";
        
        static void Main(string[] args)
        {
            int a = 10, b = 5;
            
            var mathOperation = new MathOperation();
            mathOperation.OnDivision += OnDivision;
            
            mathOperation.OnDivision += delegate(object? sender, MathOperationEventArgs e)
            {
                var words = _stringExpression.Split(" /=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var hitsCount = words.Count(str =>
                    str == Convert.ToString(e.Value1) || str == Convert.ToString(e.Value2));
            
                Console.WriteLine($"String contains {hitsCount} symbols from math expression");
            };

            mathOperation.OnDivision += (sender, e) =>
            {
                var words = _stringExpression.Split(" /=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var hitsCount = words.Count(str =>
                    str == Convert.ToString(e.Value1) || str == Convert.ToString(e.Value2));
            
                Console.WriteLine($"String contains {hitsCount} symbols from math expression");
            };

            Console.WriteLine($"{a} + {b} = {mathOperation.Sum(a, b)}");
            Console.WriteLine($"{a} - {b} = {mathOperation.Subtract(a, b)}");
            Console.WriteLine($"{a} * {b} = {mathOperation.Multiple(a, b)}");
            Console.WriteLine($"{a} / {b} = {mathOperation.Divide(a, b)}");
        }

        private static void OnDivision(object? sender, MathOperationEventArgs e)
        {
            var words = _stringExpression.Split(" /=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var hitsCount = words.Count(str =>
                str == Convert.ToString(e.Value1) || str == Convert.ToString(e.Value2));
            
            Console.WriteLine($"String contains {hitsCount} symbols from math expression");
        }
    }
}