using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_2_AbstarctionAndInterfaces
    {
        public class Customer
        {
            // Fields/Properties shared by all customers
            public string Name { get; set; }
            public decimal TotalSpent { get; protected set; }

            // Base Constructor
            public Customer(string name)
            {
                Name = name;
                TotalSpent = 0;
            }

            // 'virtual' allows child classes to override this specific behavior
            public virtual void PlaceOrder(decimal amount)
            {
                TotalSpent += amount;
                Console.WriteLine($"{Name} placed an order of ${amount}. Total spent: ${TotalSpent}");
            }
        }

        // 2. Derived Class (Child)
        // The ':' symbol establishes the inheritance chain
        public class PremiumCustomer : Customer
        {
            // Unique property belonging only to Premium Customers
            public double DiscountRate { get; set; }

            // The 'base' keyword routes parameters to the parent constructor
            public PremiumCustomer(string name, double discountRate) : base(name)
            {
                DiscountRate = discountRate;
            }

            // 'override' redefines the parent method to apply a unique premium discount
            public override void PlaceOrder(decimal amount)
            {
                // Apply the premium discount rate
                decimal discountedAmount = amount - (amount * (decimal)DiscountRate);

                // Send the updated data back up to the base method logic using 'base'
                base.PlaceOrder(discountedAmount);

                Console.WriteLine($"   --> Premium Perk: Saved ${(amount - discountedAmount):F2} on this order!");
            }
        }

        public static void Run()
        {
            // Create a Standard Customer instance
            Customer regularCustomer = new Customer("Alice");
            regularCustomer.PlaceOrder(100.00m);
            Console.WriteLine();

            // Create a Premium Customer instance
            // It automatically inherits properties like 'Name' and methods like 'PlaceOrder'
            PremiumCustomer vipCustomer = new PremiumCustomer("Bob", 0.15); // 15% discount
            vipCustomer.PlaceOrder(100.00m);
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_2_AbstarctionAndInterfaces.Run();
            }
        }
    }
}