using System;
using System.Collections.Generic;
using System.Text;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_1_Inheritance
    {
    
        // Parent Class (Base Class)
        public class BankAccount
        {
            // Protected fields are accessible within this class and by derived classes
            protected string AccountNumber { get; set; }
            public string AccountHolder { get; set; }
            public decimal Balance { get; protected set; }

            // Base Constructor
            public BankAccount(string accountHolder, string accountNumber, decimal initialBalance)
            {
                AccountHolder = accountHolder;
                AccountNumber = accountNumber;
                Balance = initialBalance;
            }

            public void Deposit(decimal amount)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
            }

            // 'virtual' allows child classes to override this method's logic
            public virtual void DisplayAccountInfo()
            {
                Console.WriteLine($"\nAccount Holder: {AccountHolder}");
                Console.WriteLine($"Account Number: {AccountNumber}");
                Console.WriteLine($"Balance: ${Balance}");
            }
        }

        // Child Class (Derived Class) inheriting from BankAccount
        public class SavingsAccount : BankAccount
        {
            public decimal InterestRate { get; set; }

            // Constructor calls the base class constructor using the 'base' keyword
            public SavingsAccount(string accountHolder, string accountNumber, decimal initialBalance, decimal interestRate)
                : base(accountHolder, accountNumber, initialBalance)
            {
                // Initialize fields unique to the child class
                InterestRate = interestRate;
            }

            public void ApplyInterest()
            {
                decimal interest = Balance * InterestRate;
                Deposit(interest);
                Console.WriteLine($"Interest of ${interest} applied at a rate of {InterestRate:P}");
            }

            // 'override' changes the behavior of the base class method
            public override void DisplayAccountInfo()
            {
                // Executes the parent class implementation first
                base.DisplayAccountInfo();
                // Adds functionality unique to the child class
                Console.WriteLine($"Interest Rate: {InterestRate:P}");
            }
        }

        // Public static method to run the demonstration
        public static void Run()
        {
            // Instantiate the derived child class
            SavingsAccount mySavings = new SavingsAccount("Alice Smith", "SAV-100234", 1000.00m, 0.05m);

            // 1. Access methods directly inherited from the parent class
            mySavings.DisplayAccountInfo();
            mySavings.Deposit(500.00m);

            // 2. Access methods unique to the child class
            mySavings.ApplyInterest();

            // 3. Display the updated information via the overridden method
            mySavings.DisplayAccountInfo();
        }

        // Keep Program class for direct execution if needed
        class Program
        {
            static void Main(string[] args)
            {
                Run();
            }
        }
    }
}
    

