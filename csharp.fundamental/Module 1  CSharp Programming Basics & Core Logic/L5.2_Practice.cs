using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L5_2_Practice
    {
        public static void Run() {

            //Practice 1 — Count Even Numbers
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int countEven = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    countEven++;
                }
            }
            Console.WriteLine("Count of even numbers: " + countEven);
            //Practice 2 — Count Positive and Negative
            int countPositive = 0;
            int countNegative = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    countPositive++;
                }
                else if (numbers[i] < 0)
                {
                    countNegative++;
                }
            }
            Console.WriteLine("Count of positive numbers: " + countPositive);
            Console.WriteLine("Count of negative numbers: " + countNegative);

            //Practice 3 — First Occurrence
            int firstOccurrence = -1;
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 5)
                {
                    firstOccurrence = i;
                    break;
                }
            }
            Console.WriteLine("First occurrence of 5: " + firstOccurrence);

            //Practice 5 — Reverse
            Console.WriteLine("Array in reverse order:");
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();

            //Practice 6 — Maximum and Minimum
            int max = numbers[0];
            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            } Console.WriteLine();

            //Practice 7 — Frequency
            int[] n = { 10, 20, 10, 30, 10, 40 };

            int target = 10;
            int count = 0;

            foreach (int number in n)
            {
                if (number == target)
                {
                    count++;
                }
            }

            Console.WriteLine($"Frequency = {count}");

            //Practice 8 — Remove Concept
            string[] fruits = { "Apple", "Banana", "Cherry" };
            List<string> tempLines = new List<string>(fruits);
            tempLines.Remove("Banana");
            fruits = tempLines.ToArray();
            Console.WriteLine(string.Join(", ", fruits));

            //Practice 9 — Compare Arrays
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 3 };

            bool equal = true;
            
            if (a.Length != b.Length)
            {
                equal = false;
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        equal = false;
                        break;
                    }
                }
            }

            Console.WriteLine(equal);

            //Practice 10 — Bubble Sort
            int[] num = { 50, 20, 40, 10, 30 };

            for (int i = 0; i < num.Length - 1; i++)
            {
                for (int j = 0; j < num.Length - 1 - i; j++)
                {
                    if (num[j] > num[j + 1])
                    {
                        int temp = num[j];

                        num[j] = num[j + 1];
                        num[j + 1] = temp;
                    }
                }
            }

            foreach (int number in num)
            {
                Console.WriteLine(number);
            }

        }
    }
}
