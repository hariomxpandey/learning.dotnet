using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L3_1_Practice
    {
        public static void Run()
        {
            //Practice 1 — Simple Method
            int result = Add(5, 10);
            Console.WriteLine($"Result of Add(5, 10) = {result}");
            //Practice 2 — Parameter
            PrintMessage("Hello, World!");
            //Practice 3 — Return Value
            int sum = Add(20, 30);
            Console.WriteLine($"Sum of 20 and 30 = {sum}");
            //Practice 4 — Square
            int number = 7;
            Console.WriteLine("Square of {0} = {1}", number, Square(number));
            //Practice 5 — Maximum
            int max = Maximum(15, 25);
            Console.WriteLine($"Maximum of 15 and 25 = {max}");
            //Practice 6 — Even Check
            int evenNumber = 10;
            Console.WriteLine($"Is {evenNumber} even? {IsEven(evenNumber)}");
            //Practice 7 — Grade
            int score = 85;
            Console.WriteLine($"Grade for score {score} = {Grade(score)}");
            //Practice 8 — String Method
            string originalString = "Hello, World!";
            Console.WriteLine($"Original string: {originalString}");
            Console.WriteLine($"Reversed string: {ReverseString(originalString)}");

            
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }
        private static void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        private static int Square(int number)
        {
            return number * number;
        }
        private static int Maximum(int a, int b)
        {
            return (a > b) ? a : b;
        }
        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        private static string Grade(int score)
        {
            if (score >= 90)
                return "A";
            else if (score >= 80)
                return "B";
            else if (score >= 70)
                return "C";
            else if (score >= 60)
                return "D";
            else
                return "F";
        }
        private static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


        }
}
