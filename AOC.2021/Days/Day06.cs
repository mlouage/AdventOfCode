namespace AOC._2021.Days;

public class Day06
{
    public int Part1(string input)
    {
        var items = input
            .Split(",", StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n))
            .ToList();

        for (int i = 1; i <= 80; i ++)
        {
            var fish = items.Select(f => f--).ToList();
            var newFish = fish.Count(f => f == 0);
            for (int j = 1; j <= newFish; j++)
            {
                fish.Append(8);

            }
            for (int k = 0; k <= fish.Count() - 1; k++)
            {
                if (fish[k] == 0)
                {
                    fish[k] = 6;
                }
            }

            items = fish;
        }

        return items.Sum();
    }

    public int Part2(string[] input)
    {
        throw new NotImplementedException();
    }    
}