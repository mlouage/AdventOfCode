using System.Text;
using System.Text.RegularExpressions;

namespace AOC._2021.Days;

public class Day14

{
    public long Part1(string input, int  steps)
    {
        return CalculatePolymer(input, steps);
    }
    
    public long Part2(string input, int steps)
    {
        var (template, insertions) = Parse(input);
        
        var pairs = new Dictionary<string, long>();
        var letters = new Dictionary<string, long>();

        foreach (var pair in CreatePairs(template).ToList())
        {
            pairs[pair] = pairs.GetValueOrDefault(pair, 0) + 1;
        }

        foreach (var letter in template.Select(c => c.ToString()))
        {
            letters[letter] = letters.GetValueOrDefault(letter, 0) + 1;
        }

        for (var i = 0; i < steps; i++)
        {
            var newPairCount = new Dictionary<string, long>();
            foreach (var pair in pairs.Keys)
            {
                var currentCount = pairs[pair];
                var added = insertions[pair];

                var newPairs = new List<string> { pair[0] + added, added + pair[1] };
                newPairs.ForEach(x => newPairCount[x] = newPairCount.GetValueOrDefault(x, 0) + currentCount);

                letters[added] = letters.GetValueOrDefault(added, 0) + currentCount;
            }

            pairs = newPairCount.ToDictionary(x => x.Key, x => x.Value);
        }

        return letters.Max(x => x.Value) - letters.Min(x => x.Value);
    }

    private static IEnumerable<string> CreatePairs(string input)
    {
        for (var i = 0; i < input.Length; i++)
        {
            if (input.Length - i >= 2)
            {
                yield return input.Substring(i, 2);
            }
        }
    }

    private static long CalculatePolymer(string input, int steps)
    {
        var (template, insertions) = Parse(input);
        var start = template;

        for (var i = 0; i < steps; i++)
        {
            var last = start.TakeLast(1);
            var text = start.ToCharArray().Select(c => c.ToString()).ToList();
            text = text.Zip(text.Skip(1), (first, second) => first + second).ToList();

            for (var j = 0; j < text.Count; j++)
            {
                var found = insertions.TryGetValue(text[j], out var insertion);

                if (!found) continue;

                var stringBuilder = new StringBuilder();
                stringBuilder.Append(text[j][0]);
                stringBuilder.Append(insertion);
                text[j] = stringBuilder.ToString();
            }

            start = string.Join(string.Empty, text) + last.First();
        }

        var result = string.Join(string.Empty, start)
            .GroupBy(c => c)
            .Select(grouping => new {grouping.Key, Count = grouping.Count()})
            .OrderByDescending(grouping => grouping.Count)
            .ToList();

        var max = result.First().Count;
        var min = result.Last().Count;

        return max - min;
    }

    

    private static (string Template, IDictionary<string, string> Insertions) Parse(string input)
    {
        var parts = input.Split("\n\n");
        var template = parts[0];
        var lines = parts[1].Split("\n");

        Dictionary<string, string> insertions = new();
        
        var regex = new Regex(@"([A-Z]+) -> ([A-Z]+)");

        foreach (var line in lines)
        {
            var match = regex.Match(line);
            insertions.Add(match.Groups[1].Value, match.Groups[2].Value);
        }

        return (Template: template, Insertions: insertions);
    }
}

