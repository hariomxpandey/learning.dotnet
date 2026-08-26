using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L5_1_Practice
    {
        public static void Run()
        {
            // Practice 1 : Create an array of integers and print the elements
            int[] arr = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Elements of the array:");
            foreach (int element in arr)
            {
                Console.WriteLine(element);
            }
            //Ppractice 2 : Array indexes access
            Console.WriteLine($"Element at index 2: {arr[2]}");

            // Practice 3 : Update an element in the array
            arr[2] = 10;
            Console.WriteLine("Array after updating element at index 2:");
            foreach (int element in arr)
            {
                Console.WriteLine(element);
            }
            // 

            // Practice 4 Calculate the sum in array 
            int[] numbers = { 1, 2, 3, 4, 5 };
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"Sum of array elements: {sum}");
            // Practice 5 Find the largest number in an array
            int[] values = { 10, 20, 5, 30, 15 };
            int largest = values[0];
            foreach (int value in values)
            {
                if (value > largest)
                {
                    largest = value;
                }
            }
            Console.WriteLine($"Largest number in the array: {largest}");
            // Practice 6 Find the smallest number in an array
            int[] nums = { 10, 20, 5, 30, 15 };
            int smallest = nums[0];
            foreach (int num in nums)
            {
                if (num < smallest)
                {
                    smallest = num;
                }
            }
            Console.WriteLine($"Smallest number in the array: {smallest}");
            //Practice 7 : Search for an element in an array
            int[] searchArray = { 10, 20, 5, 30, 15 };
            int target = 20;
            bool found = false;
            for (int i = 0; i < searchArray.Length; i++)
            {
                if (searchArray[i] == target)
                {
                    Console.WriteLine($"Element {target} found at index {i}");
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Element {target} not found in the array");
            }

            // Practice 8 : User input to populate an array
            int[] userArray = new int[5];
            Console.WriteLine("Enter 5 integers:");
            for (int i = 0; i < userArray.Length; i++)
            {
                userArray[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Elements of the user-defined array:");
            foreach (int element in userArray)
            {
                Console.WriteLine(element);
            }
            // Practice 9 : Even and odd numbers in an array
            Console.WriteLine("Even and odd numbers in the array:");
            int[] evenOddArray = { 1, 2, 3, 4, 5, 6 };
            foreach (int number in evenOddArray)
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine($"{number} is even");
                }
                else
                {
                    Console.WriteLine($"{number} is odd");
                }
            }
            // Practice 10: Average of numbers in an array
            int[] avgArray = { 10, 20, 30, 40, 50 };
            Console.WriteLine("Average of numbers in the array:");
            double average = 0;
            foreach (int number in avgArray)
            {
                average += number;
            }
            average /= avgArray.Length;
            Console.WriteLine($"Average: {average}");
        }
    }
}
