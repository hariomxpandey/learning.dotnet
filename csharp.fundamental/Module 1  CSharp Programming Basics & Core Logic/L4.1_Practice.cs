using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace csharp.fundamental.Module_1__CSharp_Programming_Basics___Core_Logic
{
    internal class L4_1_Practice
    {
        public static void Run()
        {
            

        }
        /*
         Practice 1 — Create a Class
         Create:             
         Car

         with:             
         Brand
         Model
         Year             
         Then create one object and assign values.

         Practice 2 — Add Behavior             
         Add:             
         Start()
         Drive()
         Stop()
         methods to Car.

         Practice 3 — Multiple Objects

         Create:
         Car car1 = new Car();
         Car car2 = new Car();

         Give them different
         Brand
         Model
         Year

         values.

         */

        //    class Car
        //{
        //    public string Brand { get; set; }
        //    public string Model { get; set; }
        //    public int Year { get; set; }
        //    public void Start()
        //    {
        //        Console.WriteLine($"{Brand} {Model} is starting.");
        //    }
        //    public void Drive()
        //    {
        //        Console.WriteLine($"{Brand} {Model} is driving.");
        //    }
        //    public void Stop()
        //    {
        //        Console.WriteLine($"{Brand} {Model} has stopped.");
        //    }



        /*
                  Practice 4 — Employee

                 Create:

                 Employee

                 with:

                 Name
                 Age
                 Salary

                 and:

                 DisplayDetails()
                 Work()

                class Employee
                {
                    public string Name { get; set; }
                    public int Age { get; set; }
                    public decimal Salary { get; set; }
                    public void DisplayDetails()
                    {
                        Console.WriteLine($"Name: {Name}, Age: {Age}, Salary: {Salary}");
                    }
                    public void Work()
                    {
                        Console.WriteLine($"{Name} is working.");
                    }
                }

        */

        /* 
         Practice 5 — Reference Understanding

        Predict the output:
        
        Student student1 = new Student();
        
        student1.Name = "Hariom";
        
        Student student2 = student1;
        
        student2.Name = "Aman";
        
        Console.WriteLine(student1.Name);
        Console.WriteLine(student2.Name);
        
        Don't run it first. Reason about the references.
        Answer:
        Aman
        Aman
        Why This HappensClass is a Reference Type:
        In C#, a class is a reference type.One Object in Memory:
        The line new Student() creates exactly one student object on the heap.
        Shared Reference: The variable student1 holds a pointer (reference) to that object.
        Copying the Pointer: Setting student2 = student1 copies the pointer, not the object itself.
        Two Variables, One Target: Both variables now point to the exact same memory location.
        The Overwrite: Changing student2.Name modifies the single shared object.
        The Result: Printing the name from either variable displays the updated value, "Aman".
         */

    }
}



