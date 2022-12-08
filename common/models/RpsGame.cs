using System.Runtime.CompilerServices;
using System.Xml.Schema;
using aoc2022.models.RockPaperScissors;

namespace aoc2022.models;

public class RpsGame
{
    private static Dictionary<Type, Type[]> _winConditions = new Dictionary<Type, Type[]>()
    {
        // { x plays {a,b,c} and wins }
        { typeof(Rock), new Type[] { typeof(Scissors) } },
        { typeof(Paper), new Type[] { typeof(Rock) } },
        { typeof(Scissors), new Type[] { typeof(Paper) } },
    };
    private readonly IRpsMove _opponent;
    private readonly IRpsMove _you;
    
    public RpsGame(IRpsMove opponent, IRpsMove you)
    {
        _opponent = opponent;
        _you = you;
    }

    public static Dictionary<Type, Type[]> GetWinConditions()
    {
        return _winConditions;
    }
    
    public int EvaluateScore()
    {
        int score = 0;

        if (_you.GetType() == typeof(Rock))
        {
            score += 1;
        }
        
        if (_you.GetType() == typeof(Paper))
        {
            score += 2;
        }
        
        if (_you.GetType() == typeof(Scissors))
        {
            score += 3;
        }
        
        // Draw
        if (_you.GetType() == _opponent.GetType())
        {
            score += 3;
            return score;
        }

        // You win
        if (_winConditions[_you.GetType()].Contains(_opponent.GetType()))
        {
            score += 6;
            return score;
        };
        
        // Opponent wins
        return score;

    }
}