using InventorySystem.Domain.Entities;

namespace InventorySystem.Application.Interfaces;

public interface IInventoryService
{
    int InventoryCount { get; }
    void AddProduct(Product product, params ReadOnlySpan<string> metadata);
    IEnumerable<Product> GetProducts();
}
