namespace aoc2022.models.RockPaperScissors;

public interface IRpsMove
{
    bool IsMatch<T>(T moveIdentifier);
}