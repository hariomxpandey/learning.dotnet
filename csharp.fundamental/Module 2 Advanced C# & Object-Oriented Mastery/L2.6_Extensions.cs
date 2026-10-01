using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    // ============================================================
    // EXTENSION CLASSES MUST BE TOP-LEVEL STATIC CLASSES
    // (they cannot be nested inside another class)
    // ============================================================

    public static class StringExtensions
    {
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;
            return text.Split(new[] { ' ', '\t', '\n' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string Reverse(this string text)
        {
            char[] chars = text.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

        public static string Truncate(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text) || text.Length <= maxLength)
                return text;
            return text.Substring(0, maxLength) + "...";
        }

        public static bool IsPalindrome(this string text)
        {
            string clean = new string(text.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            return clean.SequenceEqual(clean.Reverse());
        }

        public static string ToTitleCase(this string text, bool preserveAllCaps = false)
        {
            if (string.IsNullOrEmpty(text)) return text;
            var words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 0) continue;
                if (preserveAllCaps && words[i] == words[i].ToUpper()) continue;
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
            return string.Join(" ", words);
        }
    }

    public static class NumericExtensions
    {
        public static bool IsEven(this int number) => number % 2 == 0;
        public static bool IsOdd(this int number) => number % 2 != 0;

        public static bool IsPrime(this int number)
        {
            if (number < 2) return false;
            for (int i = 2; i * i <= number; i++)
                if (number % i == 0) return false;
            return true;
        }

        public static decimal PercentOf(this decimal value, decimal percent)
            => value * (percent / 100m);

        public static double ToRadians(this double degrees) => degrees * Math.PI / 180.0;
        public static double ToDegrees(this double radians) => radians * 180.0 / Math.PI;
    }

    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => source == null || !source.Any();

        public static string ToDelimitedString<T>(
            this IEnumerable<T> source, string separator = ", ")
            => string.Join(separator, source);

        public static IEnumerable<List<T>> ChunkBy<T>(
            this IEnumerable<T> source, int size)
        {
            var batch = new List<T>();
            foreach (T item in source)
            {
                batch.Add(item);
                if (batch.Count == size)
                {
                    yield return batch;
                    batch = new List<T>();
                }
            }
            if (batch.Count > 0) yield return batch;
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) return;
            foreach (T item in source) action(item);
        }

        public static IEnumerable<T> DistinctBy<T, TKey>(
            this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            var seen = new HashSet<TKey>();
            foreach (T item in source)
                if (seen.Add(keySelector(item)))
                    yield return item;
        }
    }

    public interface IEntity
    {
        int Id { get; }
    }

    public static class EntityExtensions
    {
        public static bool IsTransient(this IEntity entity)
            => entity != null && entity.Id == 0;

        public static string DescribeEntity(this IEntity entity)
            => entity == null ? "null" : $"{entity.GetType().Name}#{entity.Id}";
    }

    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<string> Tags { get; set; } = new List<string>();

        public Product(int id, string name, decimal price)
        {
            Id = id; Name = name; Price = price;
        }

        public override string ToString() => $"#{Id} {Name} (${Price:F2})";
    }

    public static class ProductExtensions
    {
        public static Product WithPrice(this Product product, decimal newPrice)
        {
            product.Price = newPrice;
            return product;
        }

        public static Product WithTag(this Product product, string tag)
        {
            product.Tags.Add(tag);
            return product;
        }

        public static bool IsAffordable(this Product product, decimal budget)
            => product.Price <= budget;

        public static decimal PriceWithTax(this Product product, decimal taxRate)
            => product.Price * (1 + taxRate);

        public static string ToDetailedString(this Product product)
            => $"{product.Name} costs {product.Price:C}" +
               (product.Tags.Any() ? $" [tags: {product.Tags.ToDelimitedString()}]" : "");
    }

    public static class DateTimeExtensions
    {
        public static bool IsWeekend(this DateTime date)
            => date.DayOfWeek == DayOfWeek.Saturday
            || date.DayOfWeek == DayOfWeek.Sunday;

        public static DateTime StartOfDay(this DateTime date) => date.Date;
        public static DateTime EndOfDay(this DateTime date)
            => date.Date.AddDays(1).AddTicks(-1);

        public static string ToRelativeTime(this DateTime date)
        {
            var span = DateTime.Now - date;
            if (span.TotalSeconds < 60) return "just now";
            if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes}m ago";
            if (span.TotalHours < 24) return $"{(int)span.TotalHours}h ago";
            if (span.TotalDays < 30) return $"{(int)span.TotalDays}d ago";
            return date.ToString("yyyy-MM-dd");
        }
    }

    public static class GenericExtensions
    {
        public static T Clamp<T>(this T value, T min, T max)
            where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        public static string SafeToString<T>(this T value)
            => value?.ToString() ?? "(null)";

        public static TResult Pipe<T, TResult>(this T value, Func<T, TResult> func)
            => func(value);

        public static T Tap<T>(this T value, Action<T> action)
        {
            action(value);
            return value;
        }
    }

    // ============================================================
    // MAIN PROGRAM
    // ============================================================
    internal class L2_6_Extensions
    {
        public static void Run()
        {
            Console.WriteLine("========== 1. STRING EXTENSIONS ==========");

            string sentence = "The quick brown fox jumps over the lazy dog";
            Console.WriteLine($"Word count: {sentence.WordCount()}");
            Console.WriteLine($"Reversed:   {"hello".Reverse()}");
            Console.WriteLine($"Truncated:  {sentence.Truncate(20)}");
            Console.WriteLine($"Palindrome? {"racecar".IsPalindrome()}");
            Console.WriteLine($"Palindrome? {"hello".IsPalindrome()}");
            Console.WriteLine($"Title case: {"the GREAT escape".ToTitleCase()}");
            Console.WriteLine($"Title case: {"the GREAT escape".ToTitleCase(preserveAllCaps: true)}");

            Console.WriteLine();
            Console.WriteLine("========== 2. NUMERIC EXTENSIONS ==========");

            Console.WriteLine($"10 is even?  {10.IsEven()}");
            Console.WriteLine($"7 is odd?    {7.IsOdd()}");
            Console.WriteLine($"17 is prime? {17.IsPrime()}");
            Console.WriteLine($"18 is prime? {18.IsPrime()}");
            Console.WriteLine($"15% of 200:  {200m.PercentOf(15)}");
            Console.WriteLine($"180° in rad: {180.0.ToRadians():F4}");
            Console.WriteLine($"π in deg:    {Math.PI.ToDegrees():F2}");

            Console.WriteLine();
            Console.WriteLine("========== 3. COLLECTION EXTENSIONS ==========");

            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine($"As string: {numbers.ToDelimitedString()}");
            Console.WriteLine($"As string: {numbers.ToDelimitedString(" | ")}");

            Console.WriteLine("Chunked by 3:");
            foreach (var chunk in numbers.ChunkBy(3))
                Console.WriteLine($"  [{chunk.ToDelimitedString()}]");

            IEnumerable<int> empty = null;
            Console.WriteLine($"Null is empty? {empty.IsNullOrEmpty()}");

            Console.WriteLine("Distinct by length (words):");
            var words = new[] { "cat", "dog", "bird", "fish", "ant", "bee" };
            foreach (var w in words.DistinctBy(w => w.Length))
                Console.WriteLine($"  {w} (length {w.Length})");

            Console.WriteLine();
            Console.WriteLine("========== 4. INTERFACE EXTENSIONS ==========");

            var product1 = new Product(0, "Draft Item", 0m);
            var product2 = new Product(42, "Laptop", 1200m);

            Console.WriteLine($"{product1.DescribeEntity()} transient? {product1.IsTransient()}");
            Console.WriteLine($"{product2.DescribeEntity()} transient? {product2.IsTransient()}");

            Console.WriteLine();
            Console.WriteLine("========== 5. CUSTOM CLASS EXTENSIONS (fluent) ==========");

            var laptop = new Product(1, "Laptop", 1200m)
                .WithPrice(1099m)
                .WithTag("electronics")
                .WithTag("sale");

            Console.WriteLine(laptop.ToDetailedString());
            Console.WriteLine($"Affordable under $1000? {laptop.IsAffordable(1000m)}");
            Console.WriteLine($"Affordable under $1500? {laptop.IsAffordable(1500m)}");
            Console.WriteLine($"Price with 8% tax:      {laptop.PriceWithTax(0.08m):C}");

            Console.WriteLine();
            Console.WriteLine("========== 6. DATETIME EXTENSIONS ==========");

            DateTime now = DateTime.Now;
            Console.WriteLine($"Now is weekend? {now.IsWeekend()}");
            Console.WriteLine($"Start of day:   {now.StartOfDay()}");
            Console.WriteLine($"End of day:     {now.EndOfDay()}");
            Console.WriteLine($"1h ago:         {now.AddHours(-1).ToRelativeTime()}");
            Console.WriteLine($"3d ago:         {now.AddDays(-3).ToRelativeTime()}");
            Console.WriteLine($"100d ago:       {now.AddDays(-100).ToRelativeTime()}");

            Console.WriteLine();
            Console.WriteLine("========== 7. GENERIC EXTENSIONS ==========");

            int score = 95;
            Console.WriteLine($"Clamp 95 to [0,100]:   {score.Clamp(0, 100)}");
            Console.WriteLine($"Clamp 150 to [0,100]:  {150.Clamp(0, 100)}");
            Console.WriteLine($"Clamp -5 to [0,100]:   {-5.Clamp(0, 100)}");

            string nullStr = null;
            Console.WriteLine($"SafeToString(null): {nullStr.SafeToString()}");
            Console.WriteLine($"SafeToString(42):   {42.SafeToString()}");

            var result = "  hello world  "
                .Trim()
                .Pipe(s => s.ToUpper())
                .Pipe(s => s.Replace(" ", "_"))
                .Pipe(s => $"[{s}]");
            Console.WriteLine($"Piped: {result}");

            var tapped = 5
                .Tap(n => Console.WriteLine($"  [Tap] value is {n}"))
                .Pipe(n => n * n)
                .Tap(n => Console.WriteLine($"  [Tap] squared is {n}"));
            Console.WriteLine($"Final: {tapped}");
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_6_Extensions.Run();
            }
        }
    }
}

