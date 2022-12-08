// See https://aka.ms/new-console-template for more information

using aoc2022.models;

Console.WriteLine("Advent of Code 2022 : Day 1");

// Define variables
List<Elf> elves = new List<Elf>();

// Read input file
string[] lines = System.IO.File.ReadAllLines(@"C:\Users\henri\RiderProjects\aoc2022\day1\input\input.txt");

Elf newElf = new Elf();
foreach (string line in lines)
{
    if (line == "")
    {
        elves.Add(newElf);
        newElf = new Elf();
        continue;
    }

    newElf.GetInventory().AddItem(new FoodItem(Convert.ToUInt32(line)));
}
elves.Add(newElf);

// Part 1: Find the elf carrying the most calories
Elf elfCarryingMostCalories = elves[0]; 
foreach (Elf elf in elves)
{
    Console.WriteLine(elf.GetInventory().GetSumCalories());
    if (elf.GetInventory().GetSumCalories() > elfCarryingMostCalories.GetInventory().GetSumCalories())
    {
        elfCarryingMostCalories = elf;
    }
}
Console.WriteLine($"Elf carrying most calories: {elfCarryingMostCalories.GetInventory().GetSumCalories()}");

// Part 2: Find the sum of the three elves carrying the most calories
uint sumTopThree = 0;
// elves.Sort((x, y) => x.GetInventory().GetSumCalories().CompareTo(y.GetInventory().GetSumCalories()));
List<Elf> sorted = elves.OrderByDescending(x => x.GetInventory().GetSumCalories()).ToList();
for (int i = 0; i <= 2; i++)
{
    Console.WriteLine($"Top 3: {sorted[i].GetInventory().GetSumCalories()}");
    sumTopThree += sorted[i].GetInventory().GetSumCalories();
}
Console.WriteLine($"Top three elves carrying in total {sumTopThree} calories");
