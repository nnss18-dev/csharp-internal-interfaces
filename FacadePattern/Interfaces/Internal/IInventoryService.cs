namespace FacadePattern.Interfaces.Internal;

/// <summary>
/// Internal interface for inventory operations
/// </summary>
internal interface IInventoryService
{
    bool CheckStock(string product, int quantity);
    void ReserveStock(string product, int quantity);
    void ReleaseStock(string product, int quantity);
}
