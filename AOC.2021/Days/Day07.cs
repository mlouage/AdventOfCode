namespace AOC._2021.Days;

public class Day07
{
    public int Part1(string input)
    {
        var positions = input
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .OrderBy(x => x)
            .ToArray();

        var median = Median(positions);

        var sum = 0;

        foreach (var position in positions)
        {
            sum += Math.Abs(position - median);
        }

        return sum;
    }

    public long Part2(string input)
    {
        var positions = input
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x))
            .OrderBy(x => x)
            .ToArray();

        var avg = Convert.ToInt32(Math.Floor(positions.Average()));

        var sum = 0;

        foreach (var position in positions)
        {
            var distance = Math.Abs(position - avg);
            sum += Enumerable.Range(1, distance).Sum();
        }

        return sum;
    }

    public static int Median(IEnumerable<int> source)
    {
        var count = source.Count();
        int itemIndex = count / 2;
        if (count % 2 == 0)
        {
            return (source.ElementAt(itemIndex) +
                    source.ElementAt(itemIndex - 1)) / 2;
        }

        return source.ElementAt(itemIndex);
    }
}