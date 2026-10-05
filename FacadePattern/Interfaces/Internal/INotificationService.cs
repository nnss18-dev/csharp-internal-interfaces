namespace FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal interface for sending notifications
/// </summary>
internal interface INotificationService
{
    void SendOrderConfirmation(string customerId, string orderId);
    void SendShippingNotification(string customerId, string orderId);
    void SendCancellationNotification(string customerId, string orderId);
}
