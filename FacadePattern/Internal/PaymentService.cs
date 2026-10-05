namespace FacadePattern.Internal;

using FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal class implementing payment processing
/// </summary>
internal class PaymentService : IPaymentService
{
    private const decimal TaxRate = 0.1m;

    public bool ProcessPayment(string customerId, decimal amount)
    {
        // Simulate payment processing
        if (amount <= 0)
            return false;

        // In real scenario, integrate with payment gateway
        Console.WriteLine($"Processing payment of ${amount} for customer {customerId}");
        return true;
    }

    public void RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine($"Refunding ${amount} for transaction {transactionId}");
    }

    public decimal CalculateTax(decimal amount)
    {
        return amount * TaxRate;
    }
}
