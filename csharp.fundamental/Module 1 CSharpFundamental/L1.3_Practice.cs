using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1_CSharpFundamental
{
    internal class L1_3_Practice
    {
        public static void Run()
        {
            Console.WriteLine("Practice 1");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your city:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your Percentage");
            double percentage = double.Parse(Console.ReadLine());
            Console.WriteLine($"\n ------- Profile Information -------");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"City: {city}");
            Console.WriteLine($"Percentage: {percentage}%");

            Console.WriteLine("\nPractice 2");
            Console.WriteLine("Enter first number :");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number :");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Sum: {num1 + num2}");

            Console.WriteLine("\nPractice 3");
            Console.WriteLine("Enter the Product Name:");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter the Product Price:");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Product Quantity:");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine($"Product Name: {productName}");
            Console.WriteLine($"Product Price: {price}");
            Console.WriteLine($"Product Quantity: {quantity}");
            Console.WriteLine($"Total Value: {price * quantity}");

            Console.WriteLine("\nPractice 4");
            Console.WriteLine("Enter age of the person:");
            bool success = int.TryParse(Console.ReadLine(), out int Age);
            if( success )
            {
                Console.WriteLine($"Age: {Age}");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for age.");
            }
            
        }
    }
}
