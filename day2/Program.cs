

// Day 2 electric boogaloo

using System.Runtime.CompilerServices;
using aoc2022.models;
using aoc2022.models.RockPaperScissors;

Console.WriteLine("Advent of Code 2022 : Day 2");

int sumScore = 0;

// Part 1
foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day2\input\test.txt"))
{
    // Extract move identifiers
    string[] moves = line.Split(" ");
    
    IRpsMove opponentMove = RpsFactory.GetMove(moves[0]) ?? throw new InvalidOperationException();
    IRpsMove yourMove = RpsFactory.GetMove(moves[1]) ?? throw new InvalidOperationException();
    
    RpsGame game = new RpsGame(opponentMove, yourMove);
    
    sumScore += game.EvaluateScore();
    
    Console.WriteLine($"{yourMove} vs. {opponentMove} Score: {game.EvaluateScore()}");
}
Console.WriteLine($"Part 1) Sum score: {sumScore}");

// Part 2
sumScore = 0;
foreach (string line in System.IO.File.ReadLines(@"C:\Users\henri\RiderProjects\aoc2022\day2\input\input.txt"))
{
    // Extract move identifiers
    string[] moves = line.Split(" ");
    
    IRpsMove opponentMove = RpsFactory.GetMove(moves[0]) ?? throw new InvalidOperationException();
    IRpsMove yourMove = opponentMove;

    string outcome = moves[1];

    switch (outcome)
    {
        case "Y": // Produce a draw
            yourMove = opponentMove;
            break;
        case "X": // Produce a loss
            Type yourMoveType = RpsGame.GetWinConditions()[opponentMove.GetType()][0];
            yourMove = (IRpsMove) Activator.CreateInstance(yourMoveType)! ?? throw new InvalidOperationException();
            break;
        case "Z": // Produce a win
            // Find a move that contains opponentMove in win condition array
            foreach (KeyValuePair<Type, Type[]> moveType in RpsGame.GetWinConditions())
            {
                if (moveType.Value.Contains(opponentMove.GetType()))
                {
                    yourMove = (IRpsMove) Activator.CreateInstance(moveType.Key)! ?? throw new InvalidOperationException();
                    break;
                }
            }
            break;
    }

    RpsGame game = new RpsGame(opponentMove, yourMove);
    
    sumScore += game.EvaluateScore();
    
    Console.WriteLine($"{yourMove} vs. {opponentMove} Score: {game.EvaluateScore()}");
}
Console.WriteLine($"Part 2) Sum score: {sumScore}");
