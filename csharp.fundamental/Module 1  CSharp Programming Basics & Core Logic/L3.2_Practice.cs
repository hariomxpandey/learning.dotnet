using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L3_2_Practice
    {
        public static void Run()
        {
            //Practice 1 — ref  (It should increase the caller's number by 10.)
            int number = 5;
            Console.WriteLine($"Original number: {number}");
            IncreaseByTen(ref number);
            Console.WriteLine($"Number after increase: {number}");

            //Practice 2 — ref (Do not use a third method or built-in swap function.)
            int a = 10;
            int b = 20;
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}");
            //Practice 3 — out (GetMinMax(int a, int b, out int min, out int max))
            int x = 15;
            int y = 25;
            GetMinMax(x, y, out int min, out int max);
            Console.WriteLine($"For numbers {x} and {y}, Min = {min}, Max = {max}");

            /*Practice 4 — out (GetFullName(
                                            string firstName,
                                            string lastName,
                                            out string fullName))
            */
            string firstName = "John";
            string lastName = "Doe";
            GetFullName(firstName, lastName, out string fullName);
            Console.WriteLine($"Full name: {fullName}");

            //Practice 5 — params (Sum(params int[] numbers))
            int totalSum = Sum(1, 2, 3, 4, 5);
            Console.WriteLine($"Total sum: {totalSum}");

            //Practice 6 — params (FindMaximum(params int[] numbers))
            int maxNumber = FindMaximum(1, 2, 3, 4, 5);
            Console.WriteLine($"Maximum number: {maxNumber}");

        }
        private static void IncreaseByTen(ref int n) 
        {
            n += 10;
        }
        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        private static void GetMinMax(int a, int b, out int min, out int max)
        {
            min = Math.Min(a, b);
            max = Math.Max(a, b);
        }
        private static void GetFullName(string firstName, string lastName, out string fullName)
        {
            fullName = $"{firstName} {lastName}";
        }

        private static int Sum(params int[] numbers)
        {
            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }
        private static int FindMaximum(params int[] numbers)
        {
            if (numbers.Length == 0)
                throw new ArgumentException("At least one number must be provided.");
            int max = numbers[0];
            foreach (int num in numbers)
            {
                if (num > max)
                    max = num;
            }
            return max;
        }
    }
}
