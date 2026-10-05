namespace FacadePattern.Interfaces;

/// <summary>
/// Public interface exposed to clients
/// </summary>
public interface IOrderService
{
    void PlaceOrder(string customerId, string product, int quantity);
    OrderStatus GetOrderStatus(string orderId);
}
