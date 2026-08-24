using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1_CSharpFundamental
{
    internal class L2_2_Practice
    {
        public static void Run()
        {
            Console.WriteLine("Practice 1");
            Console.WriteLine("Enter first number: ");
            int firstNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            int secondNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operator (+, -, *, /): ");
            string operatorSymbol = Console.ReadLine();
            int result = 0;
            bool validOperation = true;

            switch (operatorSymbol)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        validOperation = false;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid operator.");
                    validOperation = false;
                    break;
            }

            if (validOperation)
            {
                Console.WriteLine($"Result: {result}");
            }


            Console.WriteLine("Practice 2");
            Console.WriteLine("Enter the day of the week: ");
            bool isValidDay = int.TryParse(Console.ReadLine(), out int day);
            switch(day) {
                case 1: Console.WriteLine("Monday");
                    break;
                case 2: Console.WriteLine("Tuesday");
                    break;
                case 3: Console.WriteLine("Wednesday");
                    break;
                case 4: Console.WriteLine("Thursday");
                    break;
                case 5: Console.WriteLine("Friday");
                    break;
                case 6: Console.WriteLine("Saturday");
                    break;
                case 7: Console.WriteLine("Sunday");
                    break;
                default: Console.WriteLine("Invalid day of the week.");
                    break;
            }

            Console.WriteLine("Practice 3");
            Console.WriteLine("Roles available: Admin, User, Manager, Guest");
            Console.WriteLine("Enter the Role ");
            string ? role = Console.ReadLine();
            switch (role) {
                case "Admin":
                    Console.WriteLine("Welcome, Admin!");
                    break;
                case "User":
                    Console.WriteLine("Welcome, User!");
                    break;
                case "Manager":
                    Console.WriteLine("Welcome, Manager!");
                    break;
                case "Guest":
                    Console.WriteLine("Welcome, Guest!");
                    break; 

                default:
                    Console.WriteLine("Invalid role.");
                    break;
            }


            Console.WriteLine("Practice 4");
            Console.WriteLine("Enter Employee Name: ");
            string? employeeName = Console.ReadLine();
            Console.WriteLine("Employee Menu");
            Console.WriteLine("1. Add Employee \n2. View Employee \n3. Update Employee \n4. Delete Employee");
            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Adding Employee: {employeeName}");
                    break;
                case 2:
                    Console.WriteLine($"Viewing Employee: {employeeName}");
                    break;
                case 3:
                    Console.WriteLine($"Updating Employee: {employeeName}");
                    break;
                case 4:
                    Console.WriteLine($"Deleting Employee: {employeeName}");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }




        }

    }
}
