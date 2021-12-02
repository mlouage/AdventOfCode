namespace AOC._2021.Days;

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
