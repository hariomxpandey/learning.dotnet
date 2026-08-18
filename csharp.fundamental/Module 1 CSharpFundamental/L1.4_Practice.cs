using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1_CSharpFundamental
{
    internal class L1_4_Practice
    {
        public static void Run()
        {
            Console.WriteLine("Practice 1");
            Console.WriteLine("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int add = num1 + num2;
            int sub = num1 - num2;
            int mul = num1 * num2;
            double div = (double)num1 / num2;
            int mod = num1 % num2;

            Console.WriteLine("Addition: " + add);
            Console.WriteLine("Subtraction: " + sub);
            Console.WriteLine("Multiplication: " + mul);
            Console.WriteLine("Division: " + div);
            Console.WriteLine("Modulus: " + mod);

            Console.WriteLine("Practice 2");
        
            Console.WriteLine("Enter first number: ");
            int n1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int n2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(n1 == n2);
            Console.WriteLine(n1> n2);
            Console.WriteLine(n1<n2);

            Console.WriteLine("Practice 3");
            Console.WriteLine("Enter a number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            string evenOdd = (number % 2 == 0) ? "Even" : "Odd";
            Console.WriteLine("The number is: " + evenOdd);

            Console.WriteLine("Practice 4");
            Console.WriteLine("Enter a age: ");
            int Age = Convert.ToInt32(Console.ReadLine());
            bool hasID = true;
            Console.WriteLine(Age >= 18 && hasID);

            Console.WriteLine("Practice 5");
            Console.WriteLine("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            string category = (age>=18)?"Adult" : "Minor";
            Console.WriteLine("The category is: " + category);
        }

    }
}
