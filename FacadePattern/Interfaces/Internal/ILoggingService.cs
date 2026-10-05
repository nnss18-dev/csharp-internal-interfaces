namespace FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal interface for logging operations
/// </summary>
internal interface ILoggingService
{
    void LogOrder(string customerId, string orderId, string status);
    void LogError(string message, Exception? exception = null);
}
