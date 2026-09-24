using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_1_Delegates
    {
        // ============================================================
        // 1. CUSTOM DELEGATE DECLARATIONS
        //    A delegate is a type-safe function pointer.
        //    It defines the *signature* any matching method must have.
        // ============================================================

        // Takes two ints, returns an int
        public delegate int MathOperation(int a, int b);

        // Takes a string, returns nothing
        public delegate void Logger(string message);

        // Takes no args, returns a string
        public delegate string MessageProvider();

        // ============================================================
        // 2. TARGET METHODS (the methods a delegate can point to)
        // ============================================================
        public static int Add(int a, int b) => a + b;
        public static int Subtract(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;

        public static void ConsoleLogger(string message)
            => Console.WriteLine($"[Console] {message}");

        public static void FileLogger(string message)
            => Console.WriteLine($"[File]    {message}");

        public static string GreetMorning() => "Good morning!";
        public static string GreetEvening() => "Good evening!";

        // ============================================================
        // 3. DEMO METHODS
        // ============================================================

        // A method that ACCEPTS a delegate as a parameter — the classic use case.
        public static void CalculateAndPrint(int x, int y, MathOperation operation)
        {
            int result = operation(x, y);
            Console.WriteLine($"Result of {operation.Method.Name}({x}, {y}) = {result}");
        }

        // A method that RETURNS a delegate — lets the caller choose behavior.
        public static MathOperation GetOperation(string name)
        {
            return name switch
            {
                "add" => Add,
                "subtract" => Subtract,
                "multiply" => Multiply,
                _ => throw new ArgumentException($"Unknown operation: {name}")
            };
        }

        public static void Run()
        {
            Console.WriteLine("=== 1. Basic Delegate Usage ===");

            // Point the delegate at a method, then invoke it.
            MathOperation op = Add;
            Console.WriteLine($"Add: {op(10, 5)}");

            // Reassign the delegate to a different method with the same signature.
            op = Subtract;
            Console.WriteLine($"Subtract: {op(10, 5)}");

            op = Multiply;
            Console.WriteLine($"Multiply: {op(10, 5)}");

            Console.WriteLine();
            Console.WriteLine("=== 2. Delegate as a Method Parameter ===");
            CalculateAndPrint(20, 4, Add);
            CalculateAndPrint(20, 4, Subtract);

            Console.WriteLine();
            Console.WriteLine("=== 3. Multicast Delegate (multiple methods in one) ===");

            // '+' combines delegates; both loggers fire on a single invocation.
            Logger multiLogger = ConsoleLogger;
            multiLogger += FileLogger;
            multiLogger("Order placed successfully.");

            // '-' removes a delegate from the chain.
            multiLogger -= FileLogger;
            Console.WriteLine("-- after removing FileLogger --");
            multiLogger("Order shipped.");

            Console.WriteLine();
            Console.WriteLine("=== 4. Returning a Delegate ===");
            MathOperation chosen = GetOperation("multiply");
            Console.WriteLine($"Chosen op result: {chosen(6, 7)}");

            Console.WriteLine();
            Console.WriteLine("=== 5. Anonymous Methods (C# 2.0 style) ===");

            // Inline method body — no named method required.
            MathOperation anonymous = delegate (int a, int b)
            {
                return a * a + b * b;
            };
            Console.WriteLine($"Anonymous (a²+b²): {anonymous(3, 4)}");

            Console.WriteLine();
            Console.WriteLine("=== 6. Lambda Expressions (modern syntax) ===");

            MathOperation lambda = (a, b) => a - b;
            Console.WriteLine($"Lambda subtract: {lambda(10, 3)}");

            // Lambdas shine when passing behavior inline.
            CalculateAndPrint(8, 2, (a, b) => a / b);

            Console.WriteLine();
            Console.WriteLine("=== 7. Built-in Delegates: Func, Action, Predicate ===");

            // Func<T1, T2, TResult> — up to 16 params, returns a value.
            Func<int, int, int> funcAdd = (a, b) => a + b;
            Console.WriteLine($"Func add: {funcAdd(4, 5)}");

            // Action<T> — takes params, returns void.
            Action<string> actionLog = msg => Console.WriteLine($"[Action] {msg}");
            actionLog("Hello from Action");

            // Predicate<T> — takes one param, returns bool.
            Predicate<int> isEven = n => n % 2 == 0;
            Console.WriteLine($"Is 10 even? {isEven(10)}");
            Console.WriteLine($"Is 7 even?  {isEven(7)}");

            // Func with no parameters (for the MessageProvider signature)
            Func<string> provider = GreetMorning;
            Console.WriteLine(provider());

            Console.WriteLine();
            Console.WriteLine("=== 8. Practical Example: Filtering a List ===");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // The delegate (Predicate) decides which items pass the filter.
            List<int> evens = Filter(numbers, n => n % 2 == 0);
            List<int> bigOnes = Filter(numbers, n => n > 6);

            Console.WriteLine("Evens:    " + string.Join(", ", evens));
            Console.WriteLine("Over 6:   " + string.Join(", ", bigOnes));
        }

        // Generic filter that accepts a Predicate delegate.
        public static List<T> Filter<T>(List<T> source, Predicate<T> match)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (match(item)) result.Add(item);
            }
            return result;
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_1_Delegates.Run();
            }
        }
    }
}