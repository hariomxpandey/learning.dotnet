using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L4_2_Practice
    {
        public static void Run()
        {
            /* 
             
             Practice 1

            Create:

            class Car

            with instance fields:

            brand
            model
            speed
            
            Create two objects with different values.

            Answer: class Car{
                public string brand;
                public string model;
                public int speed;
                public Car(string brand, string model, int speed)
                {
                    this.brand = brand;
                    this.model = model;
                    this.speed = speed;
                }

               public void DisplayInfo()
                {
                    Console.WriteLine($"Brand: {brand}, Model: {model}, Speed: {speed}");
                }
            }
            public static void Main(string[] args){
                Car car1 = new Car("Toyota", "Camry", 120);
                Car car2 = new Car("Honda", "Civic", 130);
                car1.DisplayInfo();
                car2.DisplayInfo();

            }
             
             

            Practice 2

            Create:
            
            class Student
            
            with:
            
            name
            age
            marks
            
            Make the fields private and create a method:
            
            DisplayDetails()
            
            that prints them.

            Answer: class Student{
                private string name;
                private int age;
                private int marks;
                public Student(string name, int age, int marks)
                {
                    this.name = name;
                    this.age = age;
                    this.marks = marks;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Name: {name}, Age: {age}, Marks: {marks}");
                }
            }
            public static void Main(string[] args){
                Student student1 = new Student("John", 20, 85);
                Student student2 = new Student("Alice", 22, 90);
                student1.DisplayDetails();
                student2.DisplayDetails();
            }

            Practice 3 — Static Field

            Create:
            
            class Employee
            
            with:
            
            name
            static employeeCount
            
            Every time an employee object is created, increment employeeCount.

            Answer: class Employee{
                public string name;
                public static int employeeCount = 0;
                public Employee(string name)
                {
                    this.name = name;
                    employeeCount++;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Name: {name}, Employee Count: {employeeCount}");
                }
            }
            public static void Main(string[] args){
                Employee emp1 = new Employee("John");
                Employee emp2 = new Employee("Alice");
                emp1.DisplayDetails();
                emp2.DisplayDetails();
            }


            Practice 4 — readonly

            Create:
            
            class Product
            
            with:
            
            readonly productId
            name
            price
            
            Set productId through the constructor.
            
            Try changing it after object creation and observe the compiler error

            Answer: class Product{
                public readonly int productId;
                public string name;
                public decimal price;
                public Product(int productId, string name, decimal price)
                {
                    this.productId = productId;
                    this.name = name;
                    this.price = price;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Product ID: {productId}, Name: {name}, Price: {price}");
                }
            }
            public static void Main(string[] args){
                Product product1 = new Product(1, "Laptop", 1000.00m);
                product1.DisplayDetails();
                // product1.productId = 2; // This will cause a compiler error because productId is readonly

            Practice 5 — const

            Create:
            
            class Constants
            
            with:
            
            public const double Pi = 3.14159;
            
            Access it without creating an object.

            Answer: class Constants{
                public const double Pi = 3.14159;
            }
            public static void Main(string[] args){
                Console.WriteLine($"Value of Pi: {Constants.Pi}");
            }


            Practice 6  — Auto Properties

            Create:
            
            class Student
            
            with:
            
            Name
            Age
            Course
            
            using auto-properties.

            Answer: class Student{
                public string Name { get; set; }
                public int Age { get; set; }
                public string Course { get; set; }
                public Student(string name, int age, string course)
                {
                    Name = name;
                    Age = age;
                    Course = course;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Name: {Name}, Age: {Age}, Course: {Course}");
                }


            Practice 7 — Validation

            Create:
            
            class Employee
            
            with:
            
            Salary
            
            The salary must never be negative.
            
            Use a property with a backing field.


            Answer: class Employee{
                private decimal salary;
                public decimal Salary
                {
                    get { return salary; }
                    set
                    {
                        if (value < 0)
                        {
                            throw new ArgumentException("Salary cannot be negative.");
                        }
                        salary = value;
                    }
                }
                public Employee(decimal salary)
                {
                    Salary = salary;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Salary: {Salary}");
                }


            Practice 8 — Private Setter
            
            Create:
            
            class BankAccount
            
            with:
            
            Balance
            
            Requirements:
            
            Balance can be read publicly.
            Balance can only be changed inside the class.
            
            Add:
            
            Deposit()
            Withdraw()


            Answer: class BankAccount{
                public decimal Balance { get; private set; }
                public BankAccount(decimal initialBalance)
                {
                    Balance = initialBalance;
                }
                public void Deposit(decimal amount)
                {
                    if (amount < 0)
                    {
                        throw new ArgumentException("Deposit amount cannot be negative.");
                    }
                    Balance += amount;
                }
                public void Withdraw(decimal amount)
                {
                    if (amount < 0)
                    {
                        throw new ArgumentException("Withdraw amount cannot be negative.");
                    }
                    if (amount > Balance)
                    {
                        throw new InvalidOperationException("Insufficient funds.");
                    }
                    Balance -= amount;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Balance: {Balance}");
                }



            Practice 9 — Calculated Property

            Create:
            
            class Rectangle
            
            with:
            
            Width
            Height
            Area
            
            Make Area a calculated property.

            Answer: class Rectangle{
                public double Width { get; set; }
                public double Height { get; set; }
                public double Area
                {
                    get { return Width * Height; }
                }
                public Rectangle(double width, double height)
                {
                    Width = width;
                    Height = height;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Width: {Width}, Height: {Height}, Area: {Area}");
                }

            Practice 10 — init

            Create:
            
            class Product
            
            with:
            
            ProductId
            Name
            Price
            
            Make ProductId and Name assignable only during object initialization.


            Answer: class Product{
                public int ProductId { get; init; }
                public string Name { get; init; }
                public decimal Price { get; set; }
                public Product(int productId, string name, decimal price)
                {
                    ProductId = productId;
                    Name = name;
                    Price = price;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Product ID: {ProductId}, Name: {Name}, Price: {Price}");
                }

            Answer: class Product{
                public int ProductId { get; init; }
                public string Name { get; init; }
                public decimal Price { get; set; }
                public Product(int productId, string name, decimal price)
                {
                    ProductId = productId;
                    Name = name;
                    Price = price;
                }
                public void DisplayDetails()
                {
                    Console.WriteLine($"Product ID: {ProductId}, Name: {Name}, Price: {Price}");
                }


             */

        }
    }
}





