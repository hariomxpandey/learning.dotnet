using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L3_4_Practice
    {
        public static void Run()
        {
            //Practice 1 — Basic Overloading (Create three methods named: 2 int parameters, 3 int parameters, 2 double parameters)
             int sum = 0;
             sum = Add(5, 10);
             sum = Add(5, 10, 15);
            double dSum = Add(5.5, 10.5);

            // Practice 2 — Print

            // Create:
            Print(42);
            Print("Hello, World!");
            Print(3.14);

            // Practice 3 — Area Calculator

            //Create overloaded methods:
            int side = 4;
            int length = 5;
            int width = 6;
            double radius = 3.0;
            int area1 = Area(side);
            int area2 = Area(length, width);
            double area3 = Area(radius);

            /*Practice 4 — Constructor Overloading

              Create a Student class with:

              Student()
              Student(string name)
              Student(string name, int age)

              Store the supplied values in fields/properties.
            */
            Student();
            Student("hariom");
            Student("hariom", 22);

            /* 
             Practice 5 — Identify the Overload

               Given:
               
               static void Test(int x)
               {
               }
               
               static void Test(double x)
               {
               }
               
               static void Test(string x)
               {
               }
               
               Predict which method is called:
               
               Test(10);
               Test(10.5);
               Test("10");
            Answer: 
               Test(10); // Calls Test(int x)
               Test(10.5); // Calls Test(double x)
               Test("10"); // Calls Test(string x)
             */

        }

        private static string Student()
        {
            return "Student Name: Unknown, Age: Unknown";
        }
        private static string Student(string name)
        {
            return $"Student Name: {name}, Age: Unknown";
        }
        private static string Student(string name, int age)
        {
            return $"Student Name: {name}, Age: {age}";
        }
        private static int Area(int side)
        {
            return side * side;
        }
        private static int Area(int length, int width)
        {
            return length * width;
        }
        private static double Area(double radius)
        {
            return Math.PI * radius * radius;
        }
        private static void Print(int number)
        {
            Console.WriteLine(number);
        }
        private static void Print(string text)
        {
            Console.WriteLine(text);
        }
        private static void Print(double number)
        {
            Console.WriteLine(number);
        }
        private static int Add(int a, int b)
        {
            return a + b;
        }
        private static int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        private static double Add(double a, double b)
        {
            return a + b;
        }

    }
}
