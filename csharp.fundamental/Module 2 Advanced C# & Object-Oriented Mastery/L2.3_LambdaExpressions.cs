using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_3_LambdaExpressions
    {
        // A simple model to work with.
        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }

            public Product(string name, decimal price, int stock)
            {
                Name = name;
                Price = price;
                Stock = stock;
            }

            public override string ToString() => $"{Name} (${Price:F2}, stock {Stock})";
        }

        // A higher-order method: takes a Func as a parameter.
        public static List<T> Filter<T>(List<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (predicate(item)) result.Add(item);
            }
            return result;
        }

        // A higher-order method: returns a Func.
        public static Func<decimal, decimal> MakeDiscount(decimal rate)
            => price => price - (price * rate);

        public static void Run()
        {
            Console.WriteLine("=== 1. Lambda Syntax Forms ===");

            // Full form: explicit types + braces
            Func<int, int, int> full = (int a, int b) => { return a + b; };

            // Inferred types
            Func<int, int, int> inferred = (a, b) => a + b;

            // Single parameter — parentheses optional
            Func<int, int> square = x => x * x;

            // No parameters
            Func<string> greeting = () => "Hello, lambdas!";

            // Expression body (no braces, no return keyword)
            Func<int, bool> isEven = n => n % 2 == 0;

            Console.WriteLine($"full(3,4)     = {full(3, 4)}");
            Console.WriteLine($"inferred(3,4) = {inferred(3, 4)}");
            Console.WriteLine($"square(5)     = {square(5)}");
            Console.WriteLine($"greeting()    = {greeting()}");
            Console.WriteLine($"isEven(10)    = {isEven(10)}");

            Console.WriteLine();
            Console.WriteLine("=== 2. Statement Lambdas (multi-line) ===");

            Func<int, int, string> describe = (a, b) =>
            {
                int sum = a + b;
                string parity = sum % 2 == 0 ? "even" : "odd";
                return $"{a} + {b} = {sum} ({parity})";
            };
            Console.WriteLine(describe(7, 8));

            Console.WriteLine();
            Console.WriteLine("=== 3. Lambdas with Action (void return) ===");

            Action<string> log = msg => Console.WriteLine($"[LOG] {msg}");
            log("Lambda as an Action");

            Action<int, int> printSum = (a, b) => Console.WriteLine($"{a} + {b} = {a + b}");
            printSum(4, 6);

            Console.WriteLine();
            Console.WriteLine("=== 4. Lambdas with Predicate<T> ===");

            Predicate<int> isPositive = n => n > 0;
            Console.WriteLine($"isPositive(5)  = {isPositive(5)}");
            Console.WriteLine($"isPositive(-3) = {isPositive(-3)}");

            Console.WriteLine();
            Console.WriteLine("=== 5. Lambdas as Method Arguments ===");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> evens = Filter(numbers, n => n % 2 == 0);
            List<int> bigOnes = Filter(numbers, n => n > 6);

            Console.WriteLine("Evens:  " + string.Join(", ", evens));
            Console.WriteLine("Over 6: " + string.Join(", ", bigOnes));

            Console.WriteLine();
            Console.WriteLine("=== 6. Lambdas in LINQ ===");

            List<Product> products = new List<Product>
            {
                new Product("Laptop",    1200m, 5),
                new Product("Mouse",       25m, 50),
                new Product("Keyboard",    75m, 30),
                new Product("Monitor",    300m, 10),
                new Product("Webcam",      60m, 0)
            };

            // Where + OrderBy + Select — all take lambdas.
            var affordable = products
                .Where(p => p.Price < 500m)
                .OrderBy(p => p.Price)
                .Select(p => p.Name);

            Console.WriteLine("Affordable: " + string.Join(", ", affordable));

            // Any / All
            Console.WriteLine($"Any out of stock? {products.Any(p => p.Stock == 0)}");
            Console.WriteLine($"All under $2000?  {products.All(p => p.Price < 2000m)}");

            // Sum / Max / Min with lambdas
            Console.WriteLine($"Total stock: {products.Sum(p => p.Stock)}");
            Console.WriteLine($"Most expensive: {products.Max(p => p.Price):C}");

            // GroupBy with a lambda key selector
            var byPriceTier = products.GroupBy(p => p.Price < 100m ? "Cheap" : "Premium");
            foreach (var group in byPriceTier)
            {
                Console.WriteLine($"  {group.Key}: {string.Join(", ", group.Select(p => p.Name))}");
            }

            Console.WriteLine();
            Console.WriteLine("=== 7. Closures (capturing outer variables) ===");

            int threshold = 50;

            // This lambda "closes over" the local variable 'threshold'.
            Func<Product, bool> overThreshold = p => p.Price > threshold;

            Console.WriteLine($"Over ${threshold}: " +
                string.Join(", ", products.Where(overThreshold).Select(p => p.Name)));

            // Changing the captured variable AFTER the lambda is defined affects it.
            threshold = 400;
            Console.WriteLine($"Over ${threshold}: " +
                string.Join(", ", products.Where(overThreshold).Select(p => p.Name)));

            Console.WriteLine();
            Console.WriteLine("=== 8. Higher-Order Functions (returning a lambda) ===");

            Func<decimal, decimal> tenPercentOff = MakeDiscount(0.10m);
            Func<decimal, decimal> halfOff = MakeDiscount(0.50m);

            Console.WriteLine($"$200 with 10% off = {tenPercentOff(200m):C}");
            Console.WriteLine($"$200 with 50% off = {halfOff(200m):C}");

            Console.WriteLine();
            Console.WriteLine("=== 9. Common Pitfall: Loop Variable Capture ===");

            // BEFORE C# 5 this was buggy; today 'foreach' creates a fresh variable per iteration.
            List<Action> actions = new List<Action>();
            foreach (int i in new[] { 1, 2, 3 })
            {
                actions.Add(() => Console.WriteLine($"  foreach captured: {i}"));
            }
            foreach (var a in actions) a();

            // With a classic 'for' loop the variable is SHARED — capture a local copy!
            List<Action> badActions = new List<Action>();
            for (int i = 0; i < 3; i++)
            {
                int copy = i; // capture a fresh copy
                badActions.Add(() => Console.WriteLine($"  for captured (fixed): {copy}"));
            }
            foreach (var a in badActions) a();

            Console.WriteLine();
            Console.WriteLine("=== 10. Lambdas vs Anonymous Methods ===");

            // Anonymous method (C# 2.0)
            Func<int, int> anon = delegate (int x) { return x * 10; };

            // Equivalent lambda (C# 3.0+) — shorter, preferred.
            Func<int, int> lam = x => x * 10;

            Console.WriteLine($"anonymous: {anon(5)}");
            Console.WriteLine($"lambda:    {lam(5)}");
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_3_LambdaExpressions.Run();
            }
        }
    }
}