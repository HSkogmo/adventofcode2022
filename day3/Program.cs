// Part 1

int sumPriority = 0;

// Read file input
foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day3\input\input.txt"))
{
    // Ex. line: vJrwpWtwJgWrhcsFMMfFFhFp
    // Divide string in two equal parts
    // Find the common character in each part
    // What is the priority of the common character?
    //   Lowercase item types a through z have priorities 1 through 26.
    //   Uppercase item types A through Z have priorities 27 through 52.

    string compartmentA = line.Substring(0, (line.Length / 2));
    string compartmentB = line.Substring((line.Length / 2), (line.Length / 2));

    char[] compartmentAchars = compartmentA.ToCharArray();
    char[] compartmentBchars = compartmentB.ToCharArray();

    char commonType = compartmentAchars.Intersect(compartmentBchars).First();
    
    int priority = (int)commonType % 32;
    if (Char.IsUpper(commonType))
    {
        priority += 26;
    }
    
    Console.WriteLine($"commonType: {commonType} priority: {priority}");
    sumPriority += priority;
}
Console.WriteLine($"Part 1) Sum priority: {sumPriority}");

// Part 2
sumPriority = 0;
List<string> group = new List<string>(2);
foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day3\input\input.txt"))
{
    group.Add(line);

    if (group.Count == 3)
    {
        // Do the check on the group
        char[] elfOne = group[0].ToCharArray();
        char[] elfTwo = group[1].ToCharArray();
        char[] elfThree = group[2].ToCharArray();
        
        // common between all
        char commonType = elfOne.Intersect(elfTwo).Intersect(elfThree).First();

        int priority = (int)commonType % 32;
        if (Char.IsUpper(commonType))
        {
            priority += 26;
        }

        Console.WriteLine($"Common type: {commonType} priority: {priority}");
        sumPriority += priority;
        
        // Reset group
        group = new List<string>(2);
    }
}
Console.WriteLine($"Part 2) Sum priority: {sumPriority}");