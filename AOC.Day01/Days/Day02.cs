namespace AOC._2021.Days;
public class Day02 : IDay
{
    public int Part1(string input)
    {
        var route = input.Sanitize()
            .ConvertPlannedCourse();

        var horizontal = route
            .Where(input => input.Direction == Day02Direction.Forward)
            .Sum(input => input.Unit);

        var vertical = route
            .Where(input => input.Direction == Day02Direction.Down)
            .Sum(input => input.Unit) - route
            .Where(input => input.Direction == Day02Direction.Up)
            .Sum(input => input.Unit);

        return horizontal * vertical;
    }

    public int Part2(string input)
    {
        var aim = 0;
        var horizontal = 0;
        var depth = 0;
        var route = input.Sanitize()
            .ConvertPlannedCourse();

        foreach (var instruction in route)
        {
            if (instruction.Direction == Day02Direction.Down)
            {
                aim += instruction.Unit;
            }

            if (instruction.Direction == Day02Direction.Up)
            {
                aim -= instruction.Unit;
            }

            if (instruction.Direction == Day02Direction.Forward)
            {
                horizontal += instruction.Unit;
                depth += aim * instruction.Unit;
            }
        }

        return horizontal * depth;
    }
}

public enum Day02Direction
{
    Forward,
    Up,
    Down
}

public class Day02Instruction
{
    public Day02Direction Direction { get; set; }
    public int Unit { get; set; }
}

public static class Day02Extensions
{
    public static IEnumerable<string> Sanitize(this string input)
    {
        return input.Trim().Split(Environment.NewLine).Select(n => n.ToLowerInvariant());
    }

    public static IEnumerable<Day02Instruction> ConvertPlannedCourse(this IEnumerable<string> input)
    {
        foreach(var instruction in input)
        {
            var parts = instruction.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            yield return new Day02Instruction
            {
                Direction = parts[0] == "forward"
                    ? Day02Direction.Forward
                    : parts[0] == "up"
                        ? Day02Direction.Up
                        : Day02Direction.Down,
                Unit = int.Parse(parts[1])
            };
        }
    }

}