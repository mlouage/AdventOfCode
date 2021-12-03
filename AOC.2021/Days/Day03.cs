namespace AOC._2021.Days;
public class Day03 : IDay
{
    public int Part1(string input)
    {
        var (gamma, epsilon) = input
            .Parse()
            .Calculate()
            .CreateBinaryNumbers();

        return gamma * epsilon;
    }

    public int Part2(string input)
    {
        var (O2, Co2) = input
            .Parse()
            .CalculateO2AndCo2()
            .CreateBinaryNumbers();
        
        return O2 * Co2;
    }
}


public static class Day03Extensions
{
    public static IEnumerable<string> Parse(this string input)
    {
        return input.Trim().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
    }

    public static IEnumerable<(string, string)> Calculate(this IEnumerable<string> input)
    {
        var position = input.First().Length;

        for (int i = 0; i <= position - 1; i++)
        {
            var zero = 0;
            var one = 0;

            foreach (var item in input)
            {
                var bit = item.Substring(i, 1);

                if (bit == "0")
                {
                    zero++;
                }
                else
                {
                    one++;
                }
            }
            var mostCommon = (zero > one ? "0" : "1");
            var mostUncommon = mostCommon == "0" ? "1" : "0";

            yield return (mostCommon, mostUncommon);
        }

    }

    public enum BitCommonality
    {
        Common,
        Uncommon
    }

    public static (string, string) CalculateO2AndCo2(this IEnumerable<string> input)
    {
        var position = input.First().Length;

        var O2Numbers = input;
        var Co2Numbers = input;

        for(var i = 0; i <= position - 1; i++)
        {
            O2Numbers = calculateNumbersToKeep(O2Numbers, i, BitCommonality.Common);
            Co2Numbers = calculateNumbersToKeep(Co2Numbers, i, BitCommonality.Uncommon);
        }

        return (O2Numbers.First(), Co2Numbers.First());
    }

    private static IEnumerable<string> calculateNumbersToKeep(IEnumerable<string> input, int position, BitCommonality bitCommonality)
    {
        if (input.Count() == 1)
        {
            return input;
        }

        var zero = 0;
        var one = 0;

        foreach (var item in input)
        {
            var bit = item.Substring(position, 1);

            if (bit == "0")
            {
                zero++;
            }
            else
            {
                one++;
            }
        }

        if (bitCommonality == BitCommonality.Common)
        {
            var keep = (zero == one
                ? "1"
                : zero > one
                    ? "0"
                    : "1");

            return input.Where(i => i.Substring(position, 1) == keep);
        }
        else
        {
            var keep = (zero == one
                ? "0"
                : zero < one
                    ? "0"
                    : "1");

            return input.Where(i => i.Substring(position, 1) == keep);
        }
    }

    public static (int, int) CreateBinaryNumbers(this IEnumerable<(string, string)> input)
    {
        var gammaBinary = string.Concat(input.Select(mostCommon => mostCommon.Item1));
        var epsilonBinary = string.Concat(input.Select(mostCommon => mostCommon.Item2));

        return (Convert.ToInt32(gammaBinary, 2), Convert.ToInt32(epsilonBinary, 2));
    }

    public static (int, int) CreateBinaryNumbers(this (string, string) input)
    {
        return (Convert.ToInt32(input.Item1, 2), Convert.ToInt32(input.Item2, 2));
    }
}