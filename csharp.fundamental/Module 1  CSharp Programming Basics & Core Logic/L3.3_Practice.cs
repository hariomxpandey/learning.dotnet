using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L3_3_Practice
    {
        public static void Run()
        {
            /*  Practice 1

              Predict which lines are valid:

              int a = 10;

              if (a > 5)
              {
                  int b = 20;

                  Console.WriteLine(a); // ?  Valid , 'a' is declared in the outer scope and accessible here.
                  Console.WriteLine(b); // ? Valid , 'b' is declared in the inner scope and accessible here.
              }

              Console.WriteLine(a);     // ? Valid , 'a' is declared in the outer scope and accessible here.
              Console.WriteLine(b);     // ? Invalid , 'b' is declared in the inner scope and not accessible here.

    

              Practice 2

              What happens here ?

              for (int i = 0; i < 3; i++)
              {
                  int square = i * i;

                  Console.WriteLine(square);
              }

              Console.WriteLine(i);

              Explain why.
            Answer : The variable 'i' is declared within the for loop, so it is only accessible within that loop. Therefore, trying to access 'i' outside the loop will result in a compilation error. The variable 'square' is also local to the loop and cannot be accessed outside of it.




              Practice 3

              Identify the scope of each variable:

              static void Test(int x)
              {
                  int y = 10;

                  if (x > 5)
                  {
                      int z = 20;

                      Console.WriteLine(x);
                      Console.WriteLine(y);
                      Console.WriteLine(z);
                  }
              }

          Classify:

              x → ?
              y → ?
              z → ?
            Answer : 
              x → Parameter of the method Test, accessible throughout the method.
              y → Local variable declared inside the method Test, accessible throughout the method.
              z → Local variable declared inside the if block, accessible only within that block.



          Practice 4

         Is this valid ?

              if (true)
              {
                  int number = 10;
              }
              else
              {
                  int number = 20;
              }

              Explain why.
            Answer : This code is valid. The variable 'number' is declared in two different scopes (inside the 'if' block and inside the 'else' block). Each 'number' variable is local to its respective block, so they do not conflict with each other.

 
          Practice 5

          What is wrong?

              static void MethodA()
              {
                  int number = 10;
              }

              static void MethodB()
              {
                  Console.WriteLine(number);
              }
            Answer : The variable 'number' is declared in MethodA and is not accessible in MethodB. Each method has its own scope, and variables declared within a method are local to that method.
              */
        }
    }
}
