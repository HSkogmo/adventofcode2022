namespace aoc2022.models;

public class Elf
{
    private readonly Inventory _inventory;

    public Elf()
    {
        _inventory = new Inventory();
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }
}