namespace AOC._2021.Days;

public class Day01 : IDay
{
    public int Part1(string input)
    {
        return input
            .ConvertToNumbers()
            .CreatePair(2)
            .Aggregate(0,
                (total, pair) => pair[1] > pair[0]
                ? total + 1 : total);
    }

    public int Part2(string input)
    {
        return input
            .ConvertToNumbers()
            .CreatePair(3)
            .Select(pair => pair.Sum())
            .CreatePair(2)
            .Aggregate(0,
                (total, pair) => pair[1] > pair[0]
                ? total + 1 : total);
    }
}
