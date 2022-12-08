// Day 4: Part 1

int sumPairs = 0;

// Read file
foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day4\input\test.txt"))
{
    string[] pair = line.Split(",");
    
    string[] elfOneRangeStr = pair[0].Split('-');
    int[] elfOneRange = { Convert.ToInt32(elfOneRangeStr[0]), Convert.ToInt32(elfOneRangeStr[1]) };
    
    string[] elfTwoRangeStr = pair[1].Split('-');
    int[] elfTwoRange = { Convert.ToInt32(elfTwoRangeStr[0]), Convert.ToInt32(elfTwoRangeStr[1]) };

    Console.WriteLine($"elf1: {elfOneRange[0]}-{elfOneRange[1]} elf2: {elfTwoRange[0]}-{elfTwoRange[1]}");

    if (elfOneRange[0] <= elfTwoRange[0] && elfOneRange[1] >= elfTwoRange[1])
    {
        Console.WriteLine("Huzzah!");
        sumPairs += 1;
        continue;
    }
    
    if (elfOneRange[0] >= elfTwoRange[0] && elfOneRange[1] <= elfTwoRange[1])
    {
        Console.WriteLine("Huzzah!");
        sumPairs += 1;
        continue;
    }
}
Console.WriteLine($"Part 1) Sum pairs: {sumPairs}");


// Part 2
sumPairs = 0;

foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day4\input\input.txt"))
{
    string[] pair = line.Split(",");
    
    string[] elfOneRangeStr = pair[0].Split('-');
    int[] elfOneRangeInt = { Convert.ToInt32(elfOneRangeStr[0]), Convert.ToInt32(elfOneRangeStr[1]) };
    int[] elfOneRange = Enumerable.Range(elfOneRangeInt[0], (elfOneRangeInt[1]-elfOneRangeInt[0])+1)
        .ToArray();
    
    string[] elfTwoRangeStr = pair[1].Split('-');
    int[] elfTwoRangeInt = { Convert.ToInt32(elfTwoRangeStr[0]), Convert.ToInt32(elfTwoRangeStr[1]) };
    int[] elfTwoRange = Enumerable.Range(elfTwoRangeInt[0], (elfTwoRangeInt[1]-elfTwoRangeInt[0])+1)
        .ToArray();

    if (elfOneRange.Intersect(elfTwoRange).Any())
    {
        Console.WriteLine("Huzzah, again!");
        sumPairs += 1;
    }
    
    Console.WriteLine($"elf1: {elfOneRange.First()}-{elfOneRange.Last()} elf2: {elfTwoRange.First()}-{elfTwoRange.Last()}");
}
Console.WriteLine($"Part 2) Sum pairs: {sumPairs}");