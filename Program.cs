using FacadePattern.Facade;
using FacadePattern.Interfaces;

// ============================================
// Facade Pattern Example
// ============================================
// The client only interacts with the public IOrderService interface
// All complexity is hidden behind the OrderServiceFacade
// Internal services (Inventory, Payment, Notification, Logging) are not exposed

IOrderService orderService = new OrderServiceFacade();

Console.WriteLine("=== Facade Pattern Demo ===");
Console.WriteLine();

try
{
    // Simple public interface - hides all complexity
    orderService.PlaceOrder("CUST001", "Widget", 5);
    Console.WriteLine();

    orderService.PlaceOrder("CUST002", "Gadget", 3);
    Console.WriteLine();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("\n=== Facade Pattern Benefits ===");
Console.WriteLine("1. Simple public interface (IOrderService)");
Console.WriteLine("2. Complex internal operations hidden");
Console.WriteLine("3. Internal services not exposed to clients");
Console.WriteLine("4. Easy to maintain and modify internals");
Console.WriteLine("5. Clear separation of concerns");
