using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_5_Generics
    {
        // ============================================================
        // 1. GENERIC CLASS — a reusable container for ANY type
        //    <T> is a type parameter — a placeholder filled in at use.
        // ============================================================
        public class Box<T>
        {
            private T _item;

            public void Put(T item) => _item = item;
            public T Get() => _item;
            public bool IsEmpty => _item == null;

            public override string ToString() => $"Box<{typeof(T).Name}>: {_item}";
        }

        // ============================================================
        // 2. GENERIC CLASS WITH MULTIPLE TYPE PARAMETERS
        // ============================================================
        public class Pair<TKey, TValue>
        {
            public TKey Key { get; }
            public TValue Value { get; }

            public Pair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public override string ToString() => $"[{Key} => {Value}]";
        }

        // ============================================================
        // 3. GENERIC CLASS WITH CONSTRAINTS
        //    'where T : ...' restricts what T can be.
        // ============================================================
        public class Repository<T> where T : class, new()
        {
            private readonly List<T> _items = new List<T>();

            public void Add(T item) => _items.Add(item);
            public int Count => _items.Count;
            public T CreateNew() => new T();  // allowed because of 'new()' constraint

            public IEnumerable<T> GetAll() => _items;
        }

        // ============================================================
        // 4. GENERIC INTERFACE
        // ============================================================
        public interface IRepository<T>
        {
            void Add(T item);
            T GetById(int id);
            IEnumerable<T> GetAll();
        }

        // Concrete implementation of the generic interface
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public Product() { Name = "Unnamed"; }
            public Product(int id, string name, decimal price)
            {
                Id = id; Name = name; Price = price;
            }

            public override string ToString() => $"#{Id} {Name} (${Price:F2})";
        }

        public class ProductRepository : IRepository<Product>
        {
            private readonly List<Product> _products = new List<Product>();

            public void Add(Product item) => _products.Add(item);
            public Product GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
            public IEnumerable<Product> GetAll() => _products;
        }

        // ============================================================
        // 5. GENERIC METHODS
        // ============================================================

        // Simple generic method — works with any type
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // Generic method with a constraint (must be comparable)
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        // Generic method that transforms a list (higher-order + generics)
        public static List<TResult> Map<T, TResult>(List<T> source, Func<T, TResult> selector)
        {
            List<TResult> result = new List<TResult>();
            foreach (T item in source) result.Add(selector(item));
            return result;
        }

        // Generic method that filters
        public static List<T> Filter<T>(List<T> source, Func<T, bool> predicate)
        {
            List<T> result = new List<T>();
            foreach (T item in source)
                if (predicate(item)) result.Add(item);
            return result;
        }

        // Generic method returning a default value if null
        public static T Coalesce<T>(T value, T fallback) where T : class
        {
            return value ?? fallback;
        }

        // ============================================================
        // 6. GENERIC DELEGATE (custom)
        // ============================================================
        public delegate TResult Transformer<TInput, TResult>(TInput input);

        // ============================================================
        // 7. DEMO
        // ============================================================
        public static void Run()
        {
            Console.WriteLine("========== 1. GENERIC CLASS ==========");

            Box<int> intBox = new Box<int>();
            intBox.Put(42);
            Console.WriteLine(intBox);

            Box<string> strBox = new Box<string>();
            strBox.Put("Hello, generics!");
            Console.WriteLine(strBox);

            Box<Product> productBox = new Box<Product>();
            productBox.Put(new Product(1, "Laptop", 1200m));
            Console.WriteLine(productBox);

            Console.WriteLine();
            Console.WriteLine("========== 2. MULTIPLE TYPE PARAMETERS ==========");

            Pair<string, int> age = new Pair<string, int>("Alice", 30);
            Pair<int, string> code = new Pair<int, string>(404, "Not Found");
            Pair<string, List<string>> tags = new Pair<string, List<string>>(
                "colors", new List<string> { "red", "green", "blue" });

            Console.WriteLine(age);
            Console.WriteLine(code);
            Console.WriteLine($"{tags.Key}: {string.Join(", ", tags.Value)}");

            Console.WriteLine();
            Console.WriteLine("========== 3. GENERIC CONSTRAINTS ==========");

            Repository<Product> repo = new Repository<Product>();
            repo.Add(new Product(1, "Mouse", 25m));
            repo.Add(new Product(2, "Keyboard", 75m));
            Console.WriteLine($"Repository count: {repo.Count}");
            Console.WriteLine($"New product: {repo.CreateNew()}"); // uses new() constraint

            Console.WriteLine();
            Console.WriteLine("========== 4. GENERIC INTERFACE ==========");

            IRepository<Product> productRepo = new ProductRepository();
            productRepo.Add(new Product(10, "Monitor", 300m));
            productRepo.Add(new Product(20, "Webcam", 60m));

            Console.WriteLine("All products:");
            foreach (var p in productRepo.GetAll())
                Console.WriteLine($"  {p}");

            Console.WriteLine($"GetById(20): {productRepo.GetById(20)}");

            Console.WriteLine();
            Console.WriteLine("========== 5. GENERIC METHODS ==========");

            // Swap — works with any type
            int x = 1, y = 2;
            Console.WriteLine($"Before swap: x={x}, y={y}");
            Swap(ref x, ref y);
            Console.WriteLine($"After swap:  x={x}, y={y}");

            string s1 = "first", s2 = "second";
            Swap(ref s1, ref s2);
            Console.WriteLine($"Swapped strings: s1={s1}, s2={s2}");

            // Max — constrained to IComparable<T>
            Console.WriteLine($"Max(3, 7)          = {Max(3, 7)}");
            Console.WriteLine($"Max(\"apple\",\"pear\") = {Max("apple", "pear")}");
            Console.WriteLine($"Max(2.5m, 1.8m)    = {Max(2.5m, 1.8m)}");

            // Map & Filter — generic + lambdas
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> squares = Map(numbers, n => n * n);
            List<string> labels = Map(numbers, n => $"#{n}");
            List<int> evens = Filter(numbers, n => n % 2 == 0);

            Console.WriteLine("Squares: " + string.Join(", ", squares));
            Console.WriteLine("Labels:  " + string.Join(", ", labels));
            Console.WriteLine("Evens:   " + string.Join(", ", evens));

            // Coalesce — constrained to class (reference types)
            string nullStr = null;
            Console.WriteLine($"Coalesce(null, \"default\") = {Coalesce(nullStr, "default")}");

            Console.WriteLine();
            Console.WriteLine("========== 6. GENERIC DELEGATE ==========");

            Transformer<int, string> intToString = n => $"Number: {n}";
            Transformer<string, int> stringLength = s => s.Length;

            Console.WriteLine(intToString(42));
            Console.WriteLine($"Length of \"generics\": {stringLength("generics")}");

            Console.WriteLine();
            Console.WriteLine("========== 7. REAL-WORLD: GENERIC CACHE ==========");

            var cache = new Cache<string, Product>();
            cache.Set("p1", new Product(1, "Laptop", 1200m));
            cache.Set("p2", new Product(2, "Mouse", 25m));

            Console.WriteLine($"Cached p1: {cache.Get("p1")}");
            Console.WriteLine($"Cached p2: {cache.Get("p2")}");
            Console.WriteLine($"Has p3?    {cache.Contains("p3")}");
        }

        // ============================================================
        // 8. REAL-WORLD GENERIC CLASS: CACHE
        // ============================================================
        public class Cache<TKey, TValue>
        {
            private readonly Dictionary<TKey, TValue> _store = new Dictionary<TKey, TValue>();

            public void Set(TKey key, TValue value) => _store[key] = value;

            public TValue Get(TKey key)
                => _store.TryGetValue(key, out TValue value) ? value : default;

            public bool Contains(TKey key) => _store.ContainsKey(key);

            public int Count => _store.Count;
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_5_Generics.Run();
            }
        }
    }
}
