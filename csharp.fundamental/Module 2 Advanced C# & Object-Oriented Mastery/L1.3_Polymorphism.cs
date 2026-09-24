using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    
        internal class L2_3_Polymorphism
        {
          
            public abstract class Shape
            {
                public string Name { get; set; }

                protected Shape(string name)
                {
                    Name = name;
                }

                // 'abstract' = every derived class MUST provide its own version
                public abstract double Area();

                // 'virtual' = derived classes MAY override, but a default exists
                public virtual void Describe()
                {
                    Console.WriteLine($"I am a {Name} with area {Area():F2}");
                }

                public void Scale(double factor)
                {
                    Console.WriteLine($"{Name} scaled by {factor}x");
                }

                public void Scale(double factor, string reason)
                {
                    Console.WriteLine($"{Name} scaled by {factor}x because {reason}");
                }
            }

            public class Circle : Shape
            {
                public double Radius { get; set; }

                public Circle(double radius) : base("Circle")
                {
                    Radius = radius;
                }

                public override double Area() => Math.PI * Radius * Radius;

                public override void Describe()
                {
                    Console.WriteLine($"Circle (r={Radius}) area = {Area():F2}");
                }
            }

            public class Rectangle : Shape
            {
                public double Width { get; set; }
                public double Height { get; set; }

                public Rectangle(double width, double height) : base("Rectangle")
                {
                    Width = width;
                    Height = height;
                }

                public override double Area() => Width * Height;
                // No Describe() override — uses the base version.
            }

            public class Triangle : Shape
            {
                public double Base { get; set; }
                public double Height { get; set; }

                public Triangle(double @base, double height) : base("Triangle")
                {
                    Base = @base;
                    Height = height;
                }

                public override double Area() => 0.5 * Base * Height;
            }

            public interface IPrintable
            {
                void Print();
            }

            // A class can implement multiple interfaces — another form of polymorphism.
            public class Report : IPrintable
            {
                public string Title { get; set; }
                public Report(string title) => Title = title;

                public void Print() => Console.WriteLine($"Printing report: {Title}");
            }

            public static void Run()
            {
                Console.WriteLine("=== Runtime Polymorphism (virtual/override) ===");

                // A single list holds different concrete types.
                // The *runtime* type decides which Area()/Describe() runs.
                Shape[] shapes =
                {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 8)
            };

                foreach (Shape shape in shapes)
                {
                    // Polymorphic dispatch: calls the correct override for each type.
                    shape.Describe();
                    Console.WriteLine($"   Area via base ref: {shape.Area():F2}");
                }

                Console.WriteLine();
                Console.WriteLine("=== Compile-time Polymorphism (overloading) ===");

                Shape s = new Circle(2);
                s.Scale(1.5);                       // calls Scale(double)
                s.Scale(2.0, "inflation adjustment"); // calls Scale(double, string)

                Console.WriteLine();
                Console.WriteLine("=== Interface Polymorphism ===");

                // Different types, same interface, treated uniformly.
                IPrintable[] printables =
                {
                new Report("Q1 Earnings"),
                new Report("Annual Summary")
            };

                foreach (IPrintable p in printables)
                {
                    p.Print();
                }
            }

            class Program
            {
                static void Main(string[] args)
                {
                    L2_3_Polymorphism.Run();
                }
            }
        }
    }
