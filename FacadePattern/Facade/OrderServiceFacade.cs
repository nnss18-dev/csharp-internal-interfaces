namespace FacadePattern.Facade;

using FacadePattern.Interfaces;
using FacadePattern.Interfaces.Internal;
using FacadePattern.Internal;
using FacadePattern.Models;

/// <summary>
/// Facade Pattern Implementation
/// Simplifies complex subsystem interactions by exposing a unified public interface
/// Hides internal services (Inventory, Payment, Notification, Logging)
/// </summary>
public class OrderServiceFacade : IOrderService
{
    private readonly IInventoryService _inventoryService;
    private readonly IPaymentService _paymentService;
    private readonly INotificationService _notificationService;
    private readonly ILoggingService _loggingService;
    private readonly Dictionary<string, Order> _orders = new();

    public OrderServiceFacade()
    {
        // Initialize internal services
        _inventoryService = new InventoryService();
        _paymentService = new PaymentService();
        _notificationService = new NotificationService();
        _loggingService = new LoggingService();
    }

    /// <summary>
    /// Public method that coordinates multiple internal services
    /// Clients only see this simple interface
    /// </summary>
    public void PlaceOrder(string customerId, string product, int quantity)
    {
        try
        {
            var orderId = Guid.NewGuid().ToString();
            _loggingService.LogOrder(customerId, orderId, "Started");

            // Step 1: Check inventory
            if (!_inventoryService.CheckStock(product, quantity))
            {
                _loggingService.LogError($"Insufficient stock for {product}");
                throw new InvalidOperationException($"Insufficient stock for {product}");
            }

            // Step 2: Reserve stock
            _inventoryService.ReserveStock(product, quantity);

            // Step 3: Calculate total and process payment
            const decimal pricePerUnit = 99.99m;
            var subtotal = pricePerUnit * quantity;
            var tax = _paymentService.CalculateTax(subtotal);
            var totalAmount = subtotal + tax;

            if (!_paymentService.ProcessPayment(customerId, totalAmount))
            {
                _inventoryService.ReleaseStock(product, quantity);
                _loggingService.LogError("Payment processing failed");
                throw new InvalidOperationException("Payment processing failed");
            }

            // Step 4: Create order
            var order = new Order
            {
                OrderId = orderId,
                CustomerId = customerId,
                Product = product,
                Quantity = quantity,
                TotalAmount = totalAmount,
                Status = OrderStatus.Confirmed,
                CreatedAt = DateTime.UtcNow
            };
            _orders[orderId] = order;

            // Step 5: Send notification
            _notificationService.SendOrderConfirmation(customerId, orderId);

            // Step 6: Log success
            _loggingService.LogOrder(customerId, orderId, "Completed");
            Console.WriteLine($"✅ Order {orderId} placed successfully for customer {customerId}");
        }
        catch (Exception ex)
        {
            _loggingService.LogError($"Order placement failed: {ex.Message}", ex);
            throw;
        }
    }

    public OrderStatus GetOrderStatus(string orderId)
    {
        if (_orders.TryGetValue(orderId, out var order))
        {
            return order.Status;
        }
        throw new KeyNotFoundException($"Order {orderId} not found");
    }
}
