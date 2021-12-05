using System.Text.RegularExpressions;

namespace AOC._2021.Days;

public class Day05
{
    public int Part1(string[] input)
    {
        return Parse(input)
           .Where(line => line.IsStraight())
           .SelectMany(line => line.GetAllCoordinates())
           .GroupBy(coordinate => coordinate)
           .Where(group => group.Count() >= 2)
           .Count();
    }

    public int Part2(string[] input)
    {
        return Parse(input)
           .Where(line => line.IsStraight() || line.IsDiagonal())
           .SelectMany(line => line.GetAllCoordinates())
           .GroupBy(coordinate => coordinate)
           .Where(group => group.Count() >= 2)
           .Count();
    }

    private IEnumerable<Line> Parse(IEnumerable<string> lines)
    {
        var regex = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)");

        foreach (var line in lines)
        {
            var match = regex.Match(line);

            yield return new Line
            {
                Start = new Coordinate
                {
                    X = int.Parse(match.Groups[1].Value),
                    Y = int.Parse(match.Groups[2].Value)
                },
                End = new Coordinate
                {
                    X = int.Parse(match.Groups[3].Value),
                    Y = int.Parse(match.Groups[4].Value)
                }
            };
        }
    }
}

public record struct Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
}

public record Line
{
    public Coordinate Start { get; set; }
    public Coordinate End { get; set; }

    public bool IsStraight()
    {
        return Start.X == End.X || Start.Y == End.Y;
    }

    public bool IsDiagonal()
    {
        return Math.Abs(Start.X - End.X) == Math.Abs(Start.Y - End.Y);
    }

    public IEnumerable<Coordinate> GetAllCoordinates()
    {
        if (this.IsStraight())
        {
            var startX = Start.X < End.X ? Start.X : End.X;
            var endX = startX == Start.X ? End.X : Start.X;
            var startY = Start.Y < End.Y ? Start.Y : End.Y;
            var endY = startY == Start.Y ? End.Y : Start.Y;

            for (var x = startX; x <= endX; x++)
            {
                for (var y = startY; y <= endY; y++)
                {
                    yield return new Coordinate { X = x, Y = y };
                }
            }
        }

        if (this.IsDiagonal())
        {
            var isXDirectionUp = this.End.X > this.Start.X;
            var isYDirectionUp = this.End.Y > this.Start.Y;

            var coordinate = this.Start;

            for (var i = 0; i <= Math.Abs(this.Start.X - this.End.X); i++)
            {
                yield return coordinate;

                coordinate = coordinate with
                {
                    X = isXDirectionUp ? coordinate.X + 1 : coordinate.X - 1,
                    Y = isYDirectionUp ? coordinate.Y + 1 : coordinate.Y - 1
                };
            }
        }
    }
}