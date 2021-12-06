namespace AOC._2021.Days;

public class Day06
{
    public int Part1(string input)
    {
        var values = input
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n));

        var fishes = new int[9];

        foreach(var fish in values)
        {
            fishes[fish] += 1;
        }

        for (int i = 1; i <= 80; i ++)
        {
            var zero = fishes[0];
            for (int j = 1; j <= 8; j++)
            {
                fishes[j - 1] = fishes[j];
            }
            fishes[6] += zero;
            fishes[8] = zero;
        }

        return fishes.Sum();
    }

    public long Part2(string input)
    {
        var values = input
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(n => long.Parse(n));

        var fishes = new long[9];

        foreach (var fish in values)
        {
            fishes[fish] += 1;
        }

        for (int i = 1; i <= 256; i++)
        {
            var zero = fishes[0];
            for (int j = 1; j <= 8; j++)
            {
                fishes[j - 1] = fishes[j];
            }
            fishes[6] += zero;
            fishes[8] = zero;
        }

        return fishes.Sum();
    }    
}