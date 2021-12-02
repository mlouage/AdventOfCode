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

public static class Day01Extensions
{
    public static IEnumerable<int> ConvertToNumbers(this string input)
    {
        return input.Trim().Split(Environment.NewLine).Select(n => int.Parse(n));
    }

    public static IEnumerable<int[]> CreatePair(this IEnumerable<int> input,
        int size)
    {
        var queue = new Queue<int>(size);

        foreach (var item in input)
        {
            if (queue.Count == size)
            {
                queue.Dequeue();
            }

            queue.Enqueue(item);

            if (queue.Count == size)
            {
                yield return queue.ToArray();
            }
        }
    }
}