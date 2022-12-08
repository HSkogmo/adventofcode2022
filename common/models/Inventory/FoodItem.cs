namespace aoc2022.models;

public class FoodItem : IInventoryItem
{
    public FoodItem(uint calories)
    {
        Calories = calories;
    }

    public uint Calories { get; set; }
}