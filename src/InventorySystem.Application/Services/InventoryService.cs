using InventorySystem.Domain.Entities;
using InventorySystem.Application.Interfaces;

namespace InventorySystem.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly List<Product> _products = [];

    // Utilizes the 'field' keyword to manage backing state without manual property boilerplate.
    public int InventoryCount 
    {
        get => field; 
        private set => field = value; 
    }

    // Leverages ReadOnlySpan for zero-allocation stack-based processing of optional metadata.
    public void AddProduct(Product product, params ReadOnlySpan<string> metadata)
    {
        _products.Add(product);
        InventoryCount++;
        
        if (!metadata.IsEmpty)
        {
            Console.WriteLine($"[Info] Added '{product.Name}' with {metadata.Length} metadata items.");
        }
    }

    public IEnumerable<Product> GetProducts() => _products;
}
