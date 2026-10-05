namespace FacadePattern.Internal;

using FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal class implementing notification operations
/// </summary>
internal class NotificationService : INotificationService
{
    public void SendOrderConfirmation(string customerId, string orderId)
    {
        Console.WriteLine($"📧 Sending order confirmation to customer {customerId} for order {orderId}");
    }

    public void SendShippingNotification(string customerId, string orderId)
    {
        Console.WriteLine($"📧 Sending shipping notification to customer {customerId} for order {orderId}");
    }

    public void SendCancellationNotification(string customerId, string orderId)
    {
        Console.WriteLine($"📧 Sending cancellation notification to customer {customerId} for order {orderId}");
    }
}
