using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L4
    {
        /** 
         Practice 1 — Parameterless Constructor
       

         Create:
         
         class Student
         
         with:
         
         Name
         Age
         
         Create a parameterless constructor that initializes:
         
         Name = "Unknown"
         Age = 0

        Answer: 
                class Student
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                    public Student()
                    {
                        Name = "Unknown";
                        Age = 0;
                    }
                }
         
        Practice 2 — Parameterized Constructor

        Create:
        
        class Employee
        
        with:
        
        Name
        Salary
        
        Constructor:
        
        Employee(string name, double salary)

        Answer: 
                class Employee
                {
                    public string Name { get; set; }
                    public double Salary { get; set; }
                    public Employee(string name, double salary)
                    {
                        Name = name;
                        Salary = salary;
                    }
                }


        Practice 3 — Validation

        Create:
        
        class Product
        
        Constructor should reject:
        
        negative price
        empty product name

        Answer: 
                class Product
                {
                    public string Name { get; set; }
                    public double Price { get; set; }
                    public Product(string name, double price)
                    {
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            throw new ArgumentException("Product name cannot be empty.");
                        }
                        if (price < 0)
                        {
                            throw new ArgumentException("Price cannot be negative.");
                        }
                        Name = name;
                        Price = price;
                    }
                }

        Practice 4 — Constructor Overloading

        Create:
        
        class Student
        
        with:
        
        Student()
        Student(string name)
        Student(string name, int age)

        Answer: 
                class Student
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                    public Student()
                    {
                        Name = "Unknown";
                        Age = 0;
                    }
                    public Student(string name)
                    {
                        Name = name;
                        Age = 0;
                    }
                    public Student(string name, int age)
                    {
                        Name = name;
                        Age = age;
                    }
                }

        Practice 5 — Constructor Chaining
        Refactor the above so that only the most complete constructor performs the actual initialization.

        Use:
        
        this(...)

        Answer: 
                class Student
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                    public Student() : this("Unknown", 0) { }
                    public Student(string name) : this(name, 0) { }
                    public Student(string name, int age)
                    {
                        Name = name;
                        Age = age;
                    }
                }

        Practice 6 — Encapsulation + Constructor

        Create:
        
        class BankAccount
        
        Requirements:
        
        private balance
        
        public Balance { get; }
        
        constructor receives initial balance
        
        negative initial balance → reject
        
        Deposit()
        Withdraw()

        Answer: 
                class BankAccount
                {
                    private double balance;
                    public double Balance { get { return balance; } }
                    public BankAccount(double initialBalance)
                    {
                        if (initialBalance < 0)
                        {
                            throw new ArgumentException("Initial balance cannot be negative.");
                        }
                        balance = initialBalance;
                    }
                    public void Deposit(double amount)
                    {
                        if (amount < 0)
                        {
                            throw new ArgumentException("Deposit amount cannot be negative.");
                        }
                        balance += amount;
                    }
                    public void Withdraw(double amount)
                    {
                        if (amount < 0)
                        {
                            throw new ArgumentException("Withdraw amount cannot be negative.");
                        }
                        if (amount > balance)
                        {
                            throw new InvalidOperationException("Insufficient funds.");
                        }
                        balance -= amount;
                    }
                }




         * **/
    }
}
