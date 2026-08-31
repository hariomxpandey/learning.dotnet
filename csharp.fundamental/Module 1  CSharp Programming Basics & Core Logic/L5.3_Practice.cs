using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L5_3_Practice
    {
        public static void Run()
        {
            //Practice 1 — Character Access
            string text = "Programming";
            Console.WriteLine(text[0]);
            Console.WriteLine(text[text.Length - 1]);
            Console.WriteLine(text.Length);

            //Practice 2 — Traverse
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }

            //Practice 3 — Count Vowels
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
                {
                    count++;
                }
            }

            Console.WriteLine($"Vowels = {count}");

            //Practice 4 — Count a Character
            int count2 = 0;
            char target = 'r';
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == target)
                {
                    count2++;
                }
            }

            Console.WriteLine($"Character '{target}' = {count2}");

            // Practice 5 — Reverse String
            int count3 = 0;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Console.Write(text[i]);
            }
            // Practice 6 — Palindrome Check
            string text1 = "madam";

            bool isPalindrome = true;

            int left = 0;
            int right = text1.Length - 1;

            while (left < right)
            {
                if (text1[left] != text1[right])
                {
                    isPalindrome = false;
                    break;
                }

                left++;
                right--;
            }

            Console.WriteLine(isPalindrome);

            // Practice 7 — Remove Whitespace
            string str1 = "    Hello  World     ";
            string str2= str1.Trim();
            Console.WriteLine($"Original: '{str1}'");
            Console.WriteLine($"Trimmed: '{str2}'");

            // Practice 8 — String replace
            string str3 = "Hello World";
            string str4 = str3.Replace("World", "C#");
            Console.WriteLine($"Original: '{str3}'");
            Console.WriteLine($"Replaced: '{str4}'");
            // Practice 9 — String Split
            string names = "Hariom,Aman,Rahul";

            string[] result = names.Split(',');
            Console.WriteLine(result[0]);
            // Practice 10 — Word Count
            string sentence = "This is a sample sentence.";
            string[] words = sentence.Split(' ');
            Console.WriteLine($"Word Count: {words.Length}"); 

        }
    }
}