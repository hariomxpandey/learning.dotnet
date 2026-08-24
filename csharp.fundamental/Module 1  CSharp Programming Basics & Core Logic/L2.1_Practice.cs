using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1_CSharpFundamental
{
    internal class L2_1_Practice
    {
        public static void Run()
        {

            Console.WriteLine("Practice 1");
            Console.WriteLine("Enter a age: ");
            string ? Age = Console.ReadLine();
            int age;
            if (int.TryParse(Age, out age))
            {
                // Console.WriteLine("Valid age entered: {0}", age);
            }
            else
            {
                Console.WriteLine("Invalid age entered.");
            }

            if (age >= 18)
            {
                Console.WriteLine("You are an adult.");
            }
            else
            {
                Console.WriteLine("You are a minor.");
            }



            Console.WriteLine("Practice 2");
            Console.WriteLine("Enter the number : ");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (number < 0)
            {
                Console.WriteLine("The number is negative.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }

            Console.WriteLine("Practice 3");
            Console.WriteLine("Enter first number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            if (firstNumber > secondNumber)
            {
                Console.WriteLine("The first number is greater.");
            }
            else if (firstNumber < secondNumber)
            {
                Console.WriteLine("The second number is greater.");
            }
            else
            {
                Console.WriteLine("Both numbers are equal.");


            }


            Console.WriteLine("Practice 4");
            string Username = "admin";
            string Password = "password123";
            if (Username == "admin" && Password == "password123")
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }

            Console.WriteLine("Practice 5");
            Console.WriteLine("Enter the marks: ");
            string marksInput = Console.ReadLine();
            if (int.TryParse(marksInput, out int marks))
            {
                if (marks >= 90)
                {
                    Console.WriteLine("Grade: A");
                }
                else if (marks >= 75 && marks < 90)
                {
                    Console.WriteLine("Grade: B");
                }
                else if (marks >= 60 && marks < 75)
                {
                    Console.WriteLine("Grade: C");
                }
                else if (marks >= 50 && marks < 60)
                {
                    Console.WriteLine("Grade: D");
                }
                else
                {
                    Console.WriteLine("Grade: F");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }  
    }
}
