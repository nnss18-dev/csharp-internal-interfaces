namespace FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal interface for payment processing
/// </summary>
internal interface IPaymentService
{
    bool ProcessPayment(string customerId, decimal amount);
    void RefundPayment(string transactionId, decimal amount);
    decimal CalculateTax(decimal amount);
}
