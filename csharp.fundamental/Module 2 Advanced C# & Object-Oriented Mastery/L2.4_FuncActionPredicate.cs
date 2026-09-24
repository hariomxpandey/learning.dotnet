using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_4_FuncActionPredicate
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

        // ============================================================
        // HIGHER-ORDER METHODS that accept the built-in delegates
        // ============================================================

        // Accepts an Action<T> — performs a side effect on each item.
        public static void ForEach<T>(List<T> source, Action<T> action)
        {
            foreach (T item in source) action(item);
        }

        // Accepts a Predicate<T> — returns items that match.
        public static List<T> Filter<T>(List<T> source, Predicate<T> match)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
            {
                if (match(item)) result.Add(item);
            }
            return result;
        }

        // Accepts a Func<T, TResult> — transforms each item.
        public static List<TResult> Map<T, TResult>(List<T> source, Func<T, TResult> selector)
        {
            List<TResult> result = new List<TResult>();
            foreach (T item in source) result.Add(selector(item));
            return result;
        }

        // Accepts a Func<T, TResult> and returns a Func — factory pattern.
        public static Func<T, bool> Negate<T>(Func<T, bool> predicate)
            => item => !predicate(item);

        // Accepts an Action and a Func, showing both in one method.
        public static void Process<T>(T value, Func<T, T> transform, Action<T> output)
        {
            T transformed = transform(value);
            output(transformed);
        }

        public static void Run()
        {
            // ============================================================
            // SECTION 1 — Action<T>
            // "Does something, returns nothing" (void)
            // ============================================================
            Console.WriteLine("========== ACTION<T> ==========");

            // Action with no parameters
            Action hello = () => Console.WriteLine("Hello from Action!");
            hello();

            // Action<T> — one parameter
            Action<string> log = msg => Console.WriteLine($"[LOG] {msg}");
            log("Action with one parameter");

            // Action<T1, T2> — two parameters
            Action<string, int> repeat = (text, times) =>
            {
                for (int i = 0; i < times; i++)
                    Console.WriteLine($"  {i + 1}. {text}");
            };
            repeat("Action with two parameters", 3);

            // Action<T1, T2, T3> — three parameters
            Action<string, decimal, int> orderInfo =
                (name, price, qty) => Console.WriteLine($"  {name} x{qty} = {price * qty:C}");
            orderInfo("Widget", 9.99m, 4);

            // Action as a parameter (side effect on each item)
            List<string> names = new List<string> { "Alice", "Bob", "Carol" };
            Console.WriteLine("ForEach with Action:");
            ForEach(names, n => Console.WriteLine($"  Hi, {n}!"));

            Console.WriteLine();

            // ============================================================
            // SECTION 2 — Func<TResult>
            // "Does something AND returns a value"
            // Last type parameter is ALWAYS the return type.
            // ============================================================
            Console.WriteLine("========== FUNC<TResult> ==========");

            // Func<TResult> — no parameters, returns a value
            Func<DateTime> now = () => DateTime.Now;
            Console.WriteLine($"Now: {now():HH:mm:ss}");

            // Func<T, TResult> — one parameter, returns a value
            Func<int, int> square = x => x * x;
            Console.WriteLine($"square(6) = {square(6)}");

            // Func<T1, T2, TResult> — two parameters
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine($"add(3, 7) = {add(3, 7)}");

            // Func<T1, T2, T3, TResult> — three parameters
            Func<decimal, decimal, int, decimal> total =
                (price, taxRate, qty) => (price * qty) * (1 + taxRate);
            Console.WriteLine($"total(10, 0.08, 3) = {total(10m, 0.08m, 3):C}");

            // Func as a parameter (transform each item)
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> squares = Map(numbers, n => n * n);
            Console.WriteLine("Map to squares: " + string.Join(", ", squares));

            List<string> labels = Map(numbers, n => $"#{n}");
            Console.WriteLine("Map to labels:  " + string.Join(", ", labels));

            Console.WriteLine();

            // ============================================================
            // SECTION 3 — Predicate<T>
            // "Asks a yes/no question" — ALWAYS returns bool
            // Equivalent to Func<T, bool> but semantically clearer.
            // ============================================================
            Console.WriteLine("========== PREDICATE<T> ==========");

            // Predicate<T> — one parameter, returns bool
            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isPositive = n => n > 0;
            Predicate<string> isLong = s => s.Length > 5;

            Console.WriteLine($"isEven(10)      = {isEven(10)}");
            Console.WriteLine($"isPositive(-4)  = {isPositive(-4)}");
            Console.WriteLine($"isLong(\"hello\") = {isLong("hello")}");

            // Predicate as a parameter (filtering)
            List<int> evens = Filter(numbers, isEven);
            List<int> bigOnes = Filter(numbers, n => n > 3);
            Console.WriteLine("Evens:   " + string.Join(", ", evens));
            Console.WriteLine("Over 3:  " + string.Join(", ", bigOnes));

            // Predicate<T> with a list of objects
            List<Product> products = new List<Product>
            {
                new Product("Laptop",   1200m, 5),
                new Product("Mouse",      25m, 50),
                new Product("Keyboard",   75m, 30),
                new Product("Monitor",   300m, 10),
                new Product("Webcam",     60m, 0)
            };

            List<Product> inStock = Filter(products, p => p.Stock > 0);
            List<Product> expensive = Filter(products, p => p.Price > 100m);

            Console.WriteLine("In stock:    " + string.Join(", ", inStock.Select(p => p.Name)));
            Console.WriteLine("Expensive:   " + string.Join(", ", expensive.Select(p => p.Name)));

            Console.WriteLine();

            // ============================================================
            // SECTION 4 — Func<T, bool> vs Predicate<T>
            // They are interchangeable; Predicate is more expressive.
            // ============================================================
            Console.WriteLine("========== FUNC<T,BOOL> vs PREDICATE<T> ==========");

            Func<int, bool> funcEven = n => n % 2 == 0;
            Predicate<int> predEven = n => n % 2 == 0;

            Console.WriteLine($"Func version:      {funcEven(4)}");
            Console.WriteLine($"Predicate version: {predEven(4)}");

            // Both work with our Filter method (it takes Predicate<T>).
            // To pass a Func<T,bool>, wrap it: n => funcEven(n)
            List<int> viaFunc = Filter(numbers, n => funcEven(n));
            Console.WriteLine("Filter via Func: " + string.Join(", ", viaFunc));

            Console.WriteLine();

            // ============================================================
            // SECTION 5 — Combining Delegates (Higher-Order Functions)
            // ============================================================
            Console.WriteLine("========== COMBINING DELEGATES ==========");

            // Func returning a Func — a negated predicate
            Func<int, bool> isEvenFunc = isEven.Invoke;   // Predicate<int> → Func<int, bool>
            Func<int, bool> isOdd = Negate(isEvenFunc);
            Console.WriteLine($"isOdd(7) = {isOdd(7)}");

            // Func + Action together
            Console.WriteLine("Process (transform + output):");
            Process(10, x => x * 3, x => Console.WriteLine($"  Result: {x}"));

            // Chaining Funcs
            Func<int, int> doubleIt = x => x * 2;
            Func<int, int> addTen = x => x + 10;

            Func<int, int> combined = x => addTen(doubleIt(x));
            Console.WriteLine($"combined(5) = {combined(5)}"); // (5*2)+10 = 20

            Console.WriteLine();

            // ============================================================
            // SECTION 6 — Real-World: Validation with Predicate
            // ============================================================
            Console.WriteLine("========== REAL-WORLD VALIDATION ==========");

            Predicate<string> isValidEmail = email =>
                !string.IsNullOrWhiteSpace(email)
                && email.Contains("@")
                && email.Contains(".");

            string[] emails = { "alice@example.com", "not-an-email", "bob@site", "" };
            foreach (string email in emails)
            {
                Console.WriteLine($"  \"{email}\" valid? {isValidEmail(email)}");
            }

            Console.WriteLine();

            // ============================================================
            // SECTION 7 — Real-World: Pipeline with Func
            // ============================================================
            Console.WriteLine("========== REAL-WORLD PIPELINE ==========");

            Func<decimal, decimal> applyTax = p => p * 1.08m;
            Func<decimal, decimal> applyDiscount = p => p * 0.90m;
            Func<decimal, decimal> round = p => Math.Round(p, 2);

            // Compose a pipeline of Funcs.
            Func<decimal, decimal> pipeline = p => round(applyDiscount(applyTax(p)));

            decimal basePrice = 100m;
            Console.WriteLine($"Base:      {basePrice:C}");
            Console.WriteLine($"After all: {pipeline(basePrice):C}");

            Console.WriteLine();

            // ============================================================
            // SECTION 8 — Real-World: Action Pipeline (logging)
            // ============================================================
            Console.WriteLine("========== REAL-WORLD ACTION PIPELINE ==========");

            Action<string> consoleLog = msg => Console.WriteLine($"  [Console] {msg}");
            Action<string> fileLog = msg => Console.WriteLine($"  [File]    {msg}");
            Action<string> alertLog = msg => Console.WriteLine($"  [Alert]   {msg}");

            // Multicast Action — all three fire on one call.
            Action<string> allLogs = consoleLog + fileLog + alertLog;
            allLogs("Application started.");

            // Remove one.
            allLogs -= fileLog;
            Console.WriteLine("-- after removing fileLog --");
            allLogs("Application stopped.");
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_4_FuncActionPredicate.Run();
            }
        }
    }
}