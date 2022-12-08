namespace aoc2022.models.RockPaperScissors;

public class Scissors : IRpsMove
{
    private readonly string[] _identifiers = { "C", "Z" };
    
    public bool IsMatch<T>(T moveIdentifier)
    {
        if (moveIdentifier is not string)
        {
            return false;
        }
        return _identifiers.Contains(Convert.ToString(moveIdentifier));
    }
    
    public override string ToString()
    {
        return "Scissors";
    }
}