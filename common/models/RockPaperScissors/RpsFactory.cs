using System.Reflection;

namespace aoc2022.models.RockPaperScissors;

public static class RpsFactory
{
    public static IRpsMove? GetMove<T>(T moveIdentifier)
    {
        IEnumerable<IRpsMove> instances = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.GetInterfaces().Contains(typeof(IRpsMove)) && t.GetConstructor(Type.EmptyTypes) != null
            select Activator.CreateInstance(t) as IRpsMove;

        return instances.FirstOrDefault(instance => instance.IsMatch(moveIdentifier));
    }
}