using InventorySystem.Application.Interfaces;
using InventorySystem.Domain.Entities;
namespace InventorySystem.App;

public class App(IInventoryService inventoryService, IConsoleInterface consoleInterface)
{
    private readonly IInventoryService _inventoryService = inventoryService;
    private readonly IConsoleInterface _consoleInterface = consoleInterface;

    public void Run()
    {
        _consoleInterface.ShowHeader();

        _inventoryService.AddProduct(new Product("UltraBook Pro", 1200.00m, ["Laptop", "Electronics"]));
        _inventoryService.AddProduct(new Product("Wireless Mouse", 25.50m, ["Peripheral", "Accessories"]));

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Show List");
            Console.WriteLine("3. Exit");
            Console.Write("\nSelect [1-3]: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    _consoleInterface.AddProductUI(_inventoryService);
                    break;
                case "2":
                    _consoleInterface.ShowListUI(_inventoryService);
                    break;
                case "3":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
