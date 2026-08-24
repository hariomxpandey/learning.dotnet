using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1_CSharpFundamental
{
    internal class L2_3_Practice
    {
        public static void Run()
        {
            // Using for loop print sum of number 
            //Console.WriteLine("Enter a number to calculate the sum from 1 to that number: ");
            //  bool isValidInput = int.TryParse(Console.ReadLine(), out int number);
            //  if (isValidInput && number > 0)
            //  {
            //      int sum = 0;
            //      for (int i = 1; i <= number; i++)
            //      {
            //          sum += i;
            //      }
            //      Console.WriteLine($"The sum of numbers from 1 to {number} is: {sum}");
            //  }
            //  else
            //  {
            //      Console.WriteLine("Error: Please enter a valid positive integer.");
            //  }

            // Using for loop print multiplication table of a number
            // Console.WriteLine("Enter a number to print its multiplication table: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int  number);
            // if (isValidInput)
            // {
            //     Console.WriteLine($"Multiplication table for {number}:");
            //     for (int i = 1; i <= 10; i++)
            //     {
            //         Console.WriteLine($"{number} x {i} = {number * i}");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Error: Please enter a valid integer.");
            // }

            // Using nested for loop print a pattern of stars
            //Console.WriteLine("Enter the number of rows for the star pattern: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int rows);
            //if (isValidInput)
            //{
            //    for (int i = 1; i <= rows; i++)
            //    {
            //        for (int j = 1; j <= i; j++)
            //        {
            //            Console.Write("*");
            //        }
            //        Console.WriteLine();
            //    }

            //}
            //else
            //{
            //    Console.WriteLine("Error: Please enter a valid integer.");
            //}

            //using nested for loop print a triangle pattern of numbers
            //Console.WriteLine("Enter the number of rows for the triangle pattern: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int rows);
            //if (isValidInput)
            //{
            //    for (int i = 1; i <= rows; i++)
            //    {
            //        for (int j = 1; j <= i; j++)
            //        {
            //            Console.Write(j + " ");
            //        }
            //        Console.WriteLine();
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error: Please enter a valid integer.");
            //}
            //using infinite for loop 
            //for (; ; ) {
            //    Console.WriteLine("Infinite loop");
            //        }
            //Practice 1 — Numbers 
            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine(i);
            //}
            // Practice 2 — Reverse
            //for(int i = 100; i>= 1; i--)
            //{
            //    Console.WriteLine(i);
            //}
            // Practice 3 — Even Numbers
            //for (int i = 1; i <= 100; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            // Practice 4 — Odd Numbers
            //for (int i = 1; i <= 100; i++)
            //{
            //    if (i % 2 != 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            // Practice 5 — Factorial
            //Console.WriteLine("Enter a number to calculate its factorial: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int number);
            //int result = 1;
            //for (int i = 1; i <= number; i++)
            //{
            //    result *= i;
            //}
            //Console.WriteLine($"The factorial is: {result}");

            // now using while loop 
            //int i = 1;

            //while (i <= 5)
            //{
            //    Console.WriteLine(i);
            //    i++;
            //}

            // basic counter using while loop
            //Console.WriteLine("Enter a number to count up to: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int count);
            //int i = 1;

            //while (i <= count)
            //{
            //    Console.WriteLine("Count: " + i);
            //    i++;
            //}
            //double number = -1;

            //while (number != 0)
            //{
            //    Console.Write("Enter a number (0 to exit): ");

            //    number = double.Parse(Console.ReadLine());
            //}

            //Console.WriteLine("Program ended.");
            // Password validation using while loop
            //    string password = "";

            //    while (password != "admin123")
            //    {
            //        Console.Write("Enter password: ");
            //        password = Console.ReadLine();
            //    }

            //    Console.WriteLine("Access granted.");

            // Whilw with if statement
            //int number = 1;
            //while (number <= 10)
            //{
            //    if (number % 2 == 0)
            //    {
            //        Console.WriteLine(number + " is even.");
            //    }
            //    else
            //    {
            //        Console.WriteLine(number + " is odd.");
            //    }
            //    number++;
            //}

            //Sum  of numbers using while loop
            //int sum = 0;
            //int i = 1;
            //while (i <= 10)
            //{
            //    sum += i;
            //    i++;

            //}
            //Console.WriteLine(sum);

            // Using While loop to print multiplication table of a number
            //Console.WriteLine("Enter a number to print its multiplication table: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int number);
            //int i = 1;
            //while (i <= 10)
            //{
            //    Console.WriteLine($"{number} x {i} = {number * i}");
            //    i++;
            //}
            // Contdown using while loop
            //Console.WriteLine("Enter a number to start countdown: ");
            //bool isValidInput = int.TryParse(Console.ReadLine(), out int countdownStart);
            //if (isValidInput)
            //{
            //    while (countdownStart >= 0)
            //    {
            //        Console.WriteLine(" {0} ", countdownStart);

            //        countdownStart--;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Error: Please enter a valid integer.");
            //}

            // infinite while loop
            //while (true) {
            //    Console.WriteLine("Infinite loop. Press Ctrl+C to exit.");
            //}

            // while loop with boolean condition
            //bool continueLoop = true;
            //while (continueLoop) {
            //    Console.WriteLine("Loop is running. Press 'q' to quit.");
            //    string input = Console.ReadLine();
            //    if (input == "q") {
            //        continueLoop = false;
            //    }
            //}

            // menu driven program using while loop
            //int choice = 0;
            //while (choice != 4)
            //{
            //    Console.WriteLine("Menu:");
            //    Console.WriteLine("1. Option 1");
            //    Console.WriteLine("2. Option 2");
            //    Console.WriteLine("3. Option 3");
            //    Console.WriteLine("4. Exit");
            //    Console.Write("Enter your choice: ");
            //    bool isValidInput = int.TryParse(Console.ReadLine(), out choice);
            //    if (isValidInput)
            //    {
            //        switch (choice)
            //        {
            //            case 1:
            //                Console.WriteLine("You selected Option 1.");
            //                break;
            //            case 2:
            //                Console.WriteLine("You selected Option 2.");
            //                break;
            //            case 3:
            //                Console.WriteLine("You selected Option 3.");
            //                break;
            //            case 4:
            //                Console.WriteLine("Exiting the program.");
            //                break;
            //            default:
            //                Console.WriteLine("Invalid choice. Please try again.");
            //                break;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Error: Please enter a valid integer.");
            //

            // Practice 1 — Numbers using while loop

            //int i = 1;
            //while (i <= 10)
            //{
            //    Console.WriteLine(i);
            //    i++;
            //}
            // Practice 2 — Reverse using while loop
            //int i = 10;
            //while (i >= 1)
            //{
            //    Console.WriteLine(i);
            //    i--;
            //}

            // Practice 3 — Even Numbers using while loop
            //int i = 1;
            //while (i <= 100)
            //{
            //    if (i % 2 == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    i++;
            //}

            // Practice 4 - Sum of numbers using while loop
            //int sum = 0;
            //int i = 1;
            //while (i <= 100)
            //{
            //    sum += i;
            //    i++;
            //}
            //Console.WriteLine($"Sum of numbers from 1 to 100 is: {sum}");

            // Practice 5 - User Input Validation using while loop
            //int userInput;
            //while (true) {
            //    Console.Write("Enter a number (0 to exit): ");
            //    bool isValidInput = int.TryParse(Console.ReadLine(), out userInput);
            //    if (isValidInput) {
            //        if (userInput == 0) {
            //            break;
            //        }
            //        Console.WriteLine($"You entered: {userInput}");
            //    } else {
            //        Console.WriteLine("Error: Please enter a valid integer.");
            //    }
            //}

            // 
        }
    }
}
