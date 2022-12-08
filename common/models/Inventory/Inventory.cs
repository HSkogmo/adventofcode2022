namespace aoc2022.models;

public class Inventory
{
    private readonly List<IInventoryItem> _inventoryItems;

    public Inventory()
    {
        _inventoryItems = new List<IInventoryItem>();
    }
    
    public void AddItem(IInventoryItem inventoryItem)
    {
        _inventoryItems.Add(inventoryItem);
    }

    public uint GetSumCalories()
    {
        uint sum = 0;
        foreach (var inventoryItem in _inventoryItems)
        {
            if (inventoryItem.GetType() != typeof(FoodItem)) continue;
            var foodItem = (FoodItem) inventoryItem;
            sum += foodItem.Calories;
        }

        return sum;
    }
}