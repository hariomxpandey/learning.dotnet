using System;
using System.Collections.Generic;
using System.Text;

using System;
using System.Collections.Generic;

namespace csharp.fundamental.Module_2_Advanced_C____Object_Oriented_Mastery
{
    internal class L2_2_Events
    {
        // ============================================================
        // 1. CUSTOM EVENTARGS — carries data to subscribers
        //    Derive from EventArgs so it fits the standard .NET pattern.
        // ============================================================
        public class OrderEventArgs : EventArgs
        {
            public string CustomerName { get; }
            public decimal Amount { get; }
            public DateTime PlacedAt { get; }

            public OrderEventArgs(string customerName, decimal amount)
            {
                CustomerName = customerName;
                Amount = amount;
                PlacedAt = DateTime.Now;
            }
        }

        // ============================================================
        // 2. PUBLISHER — the class that RAISES the event
        // ============================================================
        public class OrderService
        {
            // ---- Standard .NET event using EventHandler<T> ----
            // 'event' restricts outside code to += and -= only
            // (they cannot invoke or overwrite the delegate).
            public event EventHandler<OrderEventArgs>? OrderPlaced;

            // ---- Custom delegate event (alternative style) ----
            public delegate void OrderCancelledHandler(string customer, string reason);
            public event OrderCancelledHandler? OrderCancelled;

            // ---- Another standard event with no custom data ----
            public event EventHandler? ServiceStarted;

            public void Start()
            {
                Console.WriteLine("[OrderService] Service started.");
                ServiceStarted?.Invoke(this, EventArgs.Empty);
            }

            public void PlaceOrder(string customer, decimal amount)
            {
                Console.WriteLine($"[OrderService] Placing order for {customer} (${amount})...");

                // Raise the event — the '?' guards against no subscribers.
                OrderPlaced?.Invoke(this, new OrderEventArgs(customer, amount));
            }

            public void CancelOrder(string customer, string reason)
            {
                Console.WriteLine($"[OrderService] Cancelling order for {customer}...");
                OrderCancelled?.Invoke(customer, reason);
            }
        }

        // ============================================================
        // 3. SUBSCRIBERS — classes that LISTEN for the event
        // ============================================================

        // Sends a confirmation email when an order is placed.
        public class EmailNotifier
        {
            public void OnOrderPlaced(object? sender, OrderEventArgs e)
            {
                Console.WriteLine($"  [Email] Confirmation sent to {e.CustomerName} for ${e.Amount:F2}");
            }

            public void OnServiceStarted(object? sender, EventArgs e)
            {
                Console.WriteLine("  [Email] Notification service is online.");
            }
        }

        // Logs every event for auditing.
        public class AuditLogger
        {
            public void OnOrderPlaced(object? sender, OrderEventArgs e)
            {
                Console.WriteLine($"  [Audit] Order logged at {e.PlacedAt:HH:mm:ss} — {e.CustomerName}, ${e.Amount:F2}");
            }

            public void OnOrderCancelled(string customer, string reason)
            {
                Console.WriteLine($"  [Audit] Cancellation recorded: {customer} — {reason}");
            }
        }

        // Updates inventory when an order is placed.
        public class InventoryManager
        {
            public void OnOrderPlaced(object? sender, OrderEventArgs e)
            {
                Console.WriteLine($"  [Inventory] Stock reserved for {e.CustomerName}'s order.");
            }
        }

        // ============================================================
        // 4. DEMO
        // ============================================================
        public static void Run()
        {
            Console.WriteLine("=== 1. Basic Event Subscription ===");

            OrderService service = new OrderService();
            EmailNotifier emailer = new EmailNotifier();

            // Subscribe: attach a handler to the event.
            service.OrderPlaced += emailer.OnOrderPlaced;

            service.PlaceOrder("Alice", 100.00m);

            Console.WriteLine();
            Console.WriteLine("=== 2. Multiple Subscribers (Multicast) ===");

            AuditLogger audit = new AuditLogger();
            InventoryManager inventory = new InventoryManager();

            // Every subscriber gets notified in subscription order.
            service.OrderPlaced += audit.OnOrderPlaced;
            service.OrderPlaced += inventory.OnOrderPlaced;

            service.PlaceOrder("Bob", 250.00m);

            Console.WriteLine();
            Console.WriteLine("=== 3. Unsubscribing ===");

            // Remove a handler — it will no longer be notified.
            service.OrderPlaced -= emailer.OnOrderPlaced;
            Console.WriteLine("-- EmailNotifier unsubscribed --");

            service.PlaceOrder("Carol", 75.00m);

            Console.WriteLine();
            Console.WriteLine("=== 4. Custom Delegate Event ===");

            service.OrderCancelled += audit.OnOrderCancelled;
            service.CancelOrder("Bob", "Payment declined");

            Console.WriteLine();
            Console.WriteLine("=== 5. Event with No Custom Data (EventHandler) ===");

            service.ServiceStarted += emailer.OnServiceStarted;
            service.Start();

            Console.WriteLine();
            Console.WriteLine("=== 6. Subscribing with a Lambda ===");

            // Lambdas work too — handy for one-off inline handlers.
            service.OrderPlaced += (sender, e) =>
                Console.WriteLine($"  [SMS] Text sent to {e.CustomerName}: order of ${e.Amount:F2} received.");

            service.PlaceOrder("Dave", 42.50m);

            Console.WriteLine();
            Console.WriteLine("=== 7. No Subscribers (null-safe invocation) ===");

            // If we unsubscribe everyone, the '?' prevents a NullReferenceException.
            service.OrderPlaced -= audit.OnOrderPlaced;
            service.OrderPlaced -= inventory.OnOrderPlaced;
            service.PlaceOrder("Eve", 10.00m); // Only the lambda from step 6 fires.
        }

        class Program
        {
            static void Main(string[] args)
            {
                L2_2_Events.Run();
            }
        }
    }
}