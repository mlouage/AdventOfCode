using System.Text;

namespace AOC._2021.Days;

public class Day08
{
    public int Part1(string[] input)
    {
        var digits = new Dictionary<int, int>()
        {
            { 2, 1 },
            { 4, 4 },
            { 3, 7 },
            { 7, 8 }
        };

        var sum = 0;
        var signals = Parse(input);

        foreach (var signal in signals)
        {
            if (digits.ContainsKey(signal))
            {
                sum++;
            }
        }

        return sum;
    }

    public int Part2(string[] input)
    {
        var sum = 0;

        foreach (var line in input)
        {
            var output = line.Split("|", StringSplitOptions.TrimEntries);
            var signals = output[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var digits = output[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var decoder = new SignalDecoder();
            decoder.Parse(signals);
            sum += decoder.Decode(digits);
        }

        return sum;
    }

    private IEnumerable<int> Parse(string[] input)
    {
        foreach (var line in input)
        {
            var output = line.Split("|", StringSplitOptions.TrimEntries);
            var digit_output = output[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var digit in digit_output)
            {
                yield return digit.Count();
            }
        }
    }
}

public class SignalDecoder
{
    private Dictionary<string, int> map = new Dictionary<string, int>();
    private Dictionary<int, string> invertedMap = new Dictionary<int, string>();

    public void Parse(string[] signals)
    {
        var knownSignals = signals
            .Where(s => s.Length == 2
                || s.Length == 3
                || s.Length == 4
                || s.Length == 7);

        var unknownSignalsOf5 = signals
            .Where(s => s.Length == 5);

        var unknownSignalsOf6 = signals
            .Where(s => s.Length == 6);

        foreach (var signal in knownSignals)
        {
            var sortedSignal = signal.SortString();

            if (sortedSignal.Length == 2)
            {
                map.Add(sortedSignal, 1);
                invertedMap.Add(1, sortedSignal);

                continue;
            }

            if (sortedSignal.Length == 4)
            {
                map.Add(sortedSignal, 4);
                invertedMap.Add(4, sortedSignal);

                continue;
            }

            if (sortedSignal.Length == 3)
            {
                map.Add(sortedSignal, 7);
                invertedMap.Add(7, sortedSignal);

                continue;
            }

            if (sortedSignal.Length == 7)
            {
                map.Add(sortedSignal, 8);
                invertedMap.Add(8, sortedSignal);

                continue;
            }
        }

        foreach (var signal in unknownSignalsOf6)
        {
            var sortedSignal = signal.SortString();
            var seven = invertedMap[7].ToCharArray();
            var four = invertedMap[4].ToCharArray();

            if (!seven.AllIn(sortedSignal))
            {
                map.Add(sortedSignal, 6);
                invertedMap.Add(6, sortedSignal);

                continue;
            }

            if (four.AllIn(sortedSignal))
            {
                map.Add(sortedSignal, 9);
                invertedMap.Add(9, sortedSignal);

                continue;
            }

            if (!four.AllIn(sortedSignal) && seven.AllIn(sortedSignal))
            {
                map.Add(sortedSignal, 0);
                invertedMap.Add(0, sortedSignal);

                continue;
            }

        }

        foreach (var signal in unknownSignalsOf5)
        {
            var sortedSignal = signal.SortString();
            var seven = invertedMap[7].ToCharArray();
            var six = invertedMap[6].ToCharArray();

            if (seven.AllIn(sortedSignal))
            {
                map.Add(sortedSignal, 3);
                invertedMap.Add(3, sortedSignal);

                continue;
            }

            if (sortedSignal.ToCharArray().AllIn(six))
            {
                map.Add(sortedSignal, 5);
                invertedMap.Add(5, sortedSignal);

                continue;
            }
            else
            {
                map.Add(sortedSignal, 2);
                invertedMap.Add(2, sortedSignal);

                continue;
            }
        }
    }

    public int Decode(string[] digits)
    {
        var result = new StringBuilder();

        foreach (var digit in digits)
        {
            var sortedDigit = digit.SortString();

            if (map.ContainsKey(sortedDigit))
            {
                result.Append(map[sortedDigit]);
                continue;
            }

            throw new InvalidOperationException("Digit not found in map");
        }

        return int.Parse(result.ToString());
    }
}

public static class SignalDecoderExtensions
{
    public static string SortString(this string input)
    {
        var characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }


    public static bool In(this char input, IEnumerable<char> collection)
    {
        return collection.Any(x => x == input);
    }

    public static bool AllIn(this char[] input, IEnumerable<char> collection)
    {
        return input.All(x => collection.Any(y => y == x));
    }
}