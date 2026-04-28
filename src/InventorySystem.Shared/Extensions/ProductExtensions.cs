using InventorySystem.Domain.Entities;

namespace InventorySystem.Shared.Extensions;

public static class ProductExtensions
{
    // Encapsulates discount logic; allows for easy future strategy pattern implementation.
    public static decimal GetDiscountedPrice(this Product product)
    {
        return product.Price * 0.9m;
    }
}
