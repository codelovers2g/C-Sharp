using InventorySystem.Application.Interfaces;

namespace InventorySystem.App;

public interface IConsoleInterface
{
    void ShowHeader();
    void AddProductUI(IInventoryService manager);
    void ShowListUI(IInventoryService manager);
}
