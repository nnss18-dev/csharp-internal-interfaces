namespace FacadePattern.Internal;

using FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal class implementing logging operations
/// </summary>
internal class LoggingService : ILoggingService
{
    public void LogOrder(string customerId, string orderId, string status)
    {
        Console.WriteLine($"[LOG] Customer: {customerId} | Order: {orderId} | Status: {status}");
    }

    public void LogError(string message, Exception? exception = null)
    {
        Console.WriteLine($"[ERROR] {message}");
        if (exception != null)
        {
            Console.WriteLine($"[EXCEPTION] {exception.Message}");
        }
    }
}
