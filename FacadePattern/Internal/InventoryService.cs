namespace FacadePattern.Internal;

using FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal class implementing inventory operations
/// </summary>
internal class InventoryService : IInventoryService
{
    private readonly Dictionary<string, int> _inventory = new()
    {
        { "Widget", 100 },
        { "Gadget", 50 },
        { "Tool", 75 }
    };

    public bool CheckStock(string product, int quantity)
    {
        if (_inventory.TryGetValue(product, out var stock))
        {
            return stock >= quantity;
        }
        return false;
    }

    public void ReserveStock(string product, int quantity)
    {
        if (_inventory.TryGetValue(product, out var stock))
        {
            _inventory[product] = stock - quantity;
        }
    }

    public void ReleaseStock(string product, int quantity)
    {
        if (_inventory.TryGetValue(product, out var stock))
        {
            _inventory[product] = stock + quantity;
        }
    }
}
