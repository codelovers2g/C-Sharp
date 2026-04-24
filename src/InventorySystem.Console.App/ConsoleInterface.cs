using InventorySystem.Domain.Entities;
using InventorySystem.Shared.Extensions;
using InventorySystem.Application.Interfaces;

namespace InventorySystem.App;

public class ConsoleInterface : IConsoleInterface
{
    public void ShowHeader()
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("   Modern Inventory Management System   ");
        Console.WriteLine("========================================\n");
    }

    public void AddProductUI(IInventoryService manager)
    {
        Console.WriteLine("\n--- Add New Product ---");
        
        string name;
        while (true)
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(name)) break;
            Console.WriteLine("[Error] Name cannot be empty.");
        }
        
        decimal price;
        while (true)
        {
            Console.Write("Enter Price: ");
            if (decimal.TryParse(Console.ReadLine(), out price) && price > 0) break;
            Console.WriteLine("[Error] Price must be a positive number.");
        }

        string[] tags;
        while (true)
        {
            Console.Write("Enter Tags (comma separated): ");
            string tagsInput = Console.ReadLine() ?? "";
            tags = tagsInput.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (tags.Length > 0) break;
            Console.WriteLine("[Error] At least one tag is required.");
        }

        manager.AddProduct(new Product(name, price, tags));
        Console.WriteLine("Product added successfully!");
    }

    public void ShowListUI(IInventoryService manager)
    {
        Console.WriteLine("\n--- Current Inventory ---");
        List<Product> products = manager.GetProducts().ToList();
        
        if (products.Count == 0)
        {
            Console.WriteLine("No products found.");
            return;
        }

        foreach (Product product in products)
        {
            decimal discounted = product.GetDiscountedPrice();
            string tags = string.Join(", ", product.Tags);
            Console.WriteLine($"- {product.Name,-20} | Price: ${product.Price,8:F2} | Discounted: ${discounted,8:F2} | Tags: [{tags}]");
        }
        
        Console.WriteLine($"\nTotal Items: {manager.InventoryCount}");
    }
}
