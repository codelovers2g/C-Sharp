/*
 * Latest Version Used: .NET 10 / C# 14
 * File Purpose: Advanced Inventory Management System Reference
 */

using System;
using System.Collections.Generic;
using System.Linq;

Console.WriteLine("Inventory System...");

InventoryManager manager = new InventoryManager();
manager.AddProduct(new Product("UltraBook Pro", 1200.00m, ["Laptop", "Electronics"]));
manager.AddProduct(new Product("Wireless Mouse", 25.50m, ["Peripheral", "Accessories"]), "New", "Featured", "2026 Model");

Console.WriteLine("\nInventory...");
foreach (var p in manager.GetProducts())
{
    Console.WriteLine($"- {p.Name} (${p.Price}) [Tags: {string.Join(", ", p.Tags)}]");
    Console.WriteLine($"  Discounted: ${p.DiscountedPrice:F2}");
}

string[] searchTerms = ["UltraBook", "Mouse"];
manager.SearchInventory(searchTerms);

/// <summary>
/// 1. The 'field' keyword for simplified property backing fields.
/// 2. Extension blocks for unified member extensions (methods, properties, and soon static members).
/// 3. Implicit params with ReadOnlySpan<T> for high-performance variadic arguments.
/// </summary>

public record Product(string Name, decimal Price, string[] Tags);

extension ProductExtensions for Product 
{
    // C# 14 Extension Property: Adds new members directly to the for-type
    public decimal DiscountedPrice => this.Price * 0.85m; 

    // C# 14 Extension Method
    public bool HasTag(string tag) => this.Tags.Contains(tag, StringComparer.OrdinalIgnoreCase);
}

public class InventoryManager
{
    private readonly List<Product> _products = [];

    // C# 14 Property syntax using 'field' keyword
    public int InventoryCount 
    {
        get => field; 
        private set => field = value; 
    }

    // High performance 'params ReadOnlySpan<T>' - New in modern C# (.NET 9/10)
    public void AddProduct(Product product, params ReadOnlySpan<string> metadata)
    {
        _products.Add(product);
        InventoryCount++;
        
        if (!metadata.IsEmpty)
        {
            Console.WriteLine($"Added {product.Name} with {metadata.Length} metadata items.");
        }
    }

    public IEnumerable<Product> GetProducts() => _products;

    public void SearchInventory(ReadOnlySpan<string> terms)
    {
        Console.WriteLine($"\nSearching for {terms.Length} terms...");
        foreach (var term in terms)
        {
            var found = _products.Where(p => p.Name.Contains(term));
            Console.WriteLine($"Term '{term}': {found.Count()} match(es) found.");
        }
    }
}
