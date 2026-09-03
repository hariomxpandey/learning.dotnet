using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L4_3_Practice

    {

        public static void Run()
        {
            /*
             
             Practice 1 — Private Field
             Create:

            class Student
            
            with:
            
            private age
            public Name
            
            Create a method to safely update age.

            Answer: 
                  class Student
                  {
                      private int age;
                      public string Name { get; set; }
                      public void SetAge(int newAge)
                      {
                          if (newAge >= 0)
                          {
                              age = newAge;
                          }
                          else
                          {
                              throw new ArgumentException("Age cannot be negative.");
                          }
                      }
                      public int GetAge()
                      {
                          return age;
                      }
                  }

            Practice 2 — Validation

            Create:
            
            class Product
            
            with:
            
            private price
            public Price property
            
            Rule:
            
            price >= 0

            Answer:
                  class Product
                  {
                      private decimal price;
                      public decimal Price
                      {
                          get { return price; }
                          set
                          {
                              if (value >= 0)
                              {
                                  price = value;
                              }
                              else
                              {
                                  throw new ArgumentException("Price cannot be negative.");
                              }
                          }
                      }
                  }


            Practice 3 — Private Setter

            Create:
            
            class BankAccount
            
            with:
            
            public double Balance { get; private set; }
            
            Create:
            
            Deposit()
            Withdraw()

            Answer:
                  class BankAccount
                  {
                      public double Balance { get; private set; }
                      public void Deposit(double amount)
                      {
                          if (amount > 0)
                          {
                              Balance += amount;
                          }
                          else
                          {
                              throw new ArgumentException("Deposit amount must be positive.");
                          }
                      }
                      public void Withdraw(double amount)
                      {
                          if (amount > 0 && amount <= Balance)
                          {
                              Balance -= amount;
                          }
                          else
                          {
                              throw new ArgumentException("Invalid withdrawal amount.");
                          }
                      }
                  }


            Practice 4 — Protected

            Create:
            
            class Animal
            {
                protected string name;
            }
            
            Then create:
            
            class Dog : Animal
            
            and access name from Dog.
            
            Then try accessing name from Main().
            
            Observe the difference.

            Answer:
                  class Animal
                  {
                      protected string name;
                      public Animal(string name)
                      {
                          this.name = name;
                      }
                  }
                  class Dog : Animal
                  {
                      public Dog(string name) : base(name) { }
                      public void Bark()
                      {
                          Console.WriteLine($"{name} says Woof!");
                      }
                  }
                  // In Main():
                  // Dog dog = new Dog("Buddy");
                  // dog.Bark(); // This works and prints "Buddy says Woof!"
                  // Console.WriteLine(dog.name); // This will cause a compile-time error because 'name' is protected and cannot be accessed from outside the class hierarchy.


             Practice 5 — Internal

             Create an internal member and understand that it is accessible from code in the same assembly

            Answer:
                  internal class InternalExample
                  {
                      internal string InternalData { get; set; }
                      public InternalExample(string data)
                      {
                          InternalData = data;
                      }
                  }
                  // In the same assembly, you can access InternalData:
                  // InternalExample example = new InternalExample("Hello");
                  // Console.WriteLine(example.InternalData); // This works because it's in the same assembly.



          
             */
        }
    }
}
