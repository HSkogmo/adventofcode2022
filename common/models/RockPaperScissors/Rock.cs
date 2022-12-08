namespace aoc2022.models.RockPaperScissors;

public class Rock : IRpsMove
{
    private readonly string[] _identifiers = { "A", "X" };
    
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
        return "Rock";
    }
}