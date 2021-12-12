namespace AOC._2021.Days;

public class Day11
{
    public List<(int Row, int Column)> Offsets = new()
    {
        (-1, -1),
        (-1, 0),
        (-1, 1),
        (0, -1),
        (0, 1),
        (1, -1),
        (1, 0),
        (1, 1),
    };

    public int Part1(string[] input, int steps)
    {
        var grid = input.Parse();
        var flashes = 0;
        List<Cell> alreadyFlashed = new();

        for (var i = 1; i <= steps; i++)
        {
            var flashesInStep = 0;
            grid.AddOne();

            do
            {
                flashesInStep = 0;

                var cells = grid.Cells();

                foreach (var cell in cells)
                {
                    if (alreadyFlashed.Contains(cell))
                    {
                        continue;
                    }

                    if (grid.At(cell) > 9)
                    {
                        flashesInStep++;
                        alreadyFlashed.Add(cell);

                        Offsets
                            .Select(offset => new Cell { Row = cell.Row + offset.Row, Column = cell.Column + offset.Column })
                            .Where(cell => grid.IsInBounds(cell))
                            .AddOne(grid);
                    }
                }

            } while (flashesInStep != 0);

            foreach (var cell in alreadyFlashed)
            {
                grid.Set(cell, 0);
            }

            flashes += alreadyFlashed.Count;
            alreadyFlashed = new();
        }

        return flashes;
    }

    public int Part2(string[] input, int steps)
    {
        var grid = input.Parse();
        var flashes = 0;
        List<Cell> alreadyFlashed = new();

        for (var i = 1; i <= steps; i++)
        {
            var flashesInStep = 0;
            grid.AddOne();

            do
            {
                flashesInStep = 0;

                var cells = grid.Cells();

                foreach (var cell in cells)
                {
                    if (alreadyFlashed.Contains(cell))
                    {
                        continue;
                    }

                    if (grid.At(cell) > 9)
                    {
                        flashesInStep++;
                        alreadyFlashed.Add(cell);

                        Offsets
                            .Select(offset => new Cell { Row = cell.Row + offset.Row, Column = cell.Column + offset.Column })
                            .Where(cell => grid.IsInBounds(cell))
                            .AddOne(grid);
                    }
                }

            } while (flashesInStep != 0);

            if (alreadyFlashed.Count == 100)
                return i;

            foreach (var cell in alreadyFlashed)
            {
                grid.Set(cell, 0);
            }

            flashes += alreadyFlashed.Count;
            alreadyFlashed = new();
        }

        return flashes;
    }

    
}

public static class Day11Extensions
{
    public static int[,] Parse(this string[] input)
    {
        var x = input.Count();
        var y = input.First().Count();

        var matrix = new int[x, y];

        for (int i = 0; i < x; i++)
        {
            var items = input[i]
                .ToCharArray()
                .Select(x => x.ToString())
                .Select(x => int.Parse(x))
                .ToArray();

            for (int j = 0; j < y; j++)
            {
                matrix[i, j] = items[j];
            }
        }

        return matrix;
    }

    public static bool IsInBounds<T>(this T[,] matrix, Cell position)
    {
        int columns = matrix.GetLength(0);
        int rows = matrix.GetLength(1);

        return position.Row >= 0 && position.Row < rows && position.Column >= 0 && position.Column < columns;
    }

    public static IEnumerable<Cell> Cells<T>(this T[,] matrix)
    {
        int columns = matrix.GetLength(0);
        int rows = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                yield return new Cell { Row = i, Column = j };
            }
        }
    }

    public static T At<T>(this T[,] input, Cell position)
    {
        return input[position.Row, position.Column];
    }

    public static void Set<T>(this T[,] input, Cell position, T value)
    {
        input[position.Row, position.Column] = value;
    }

    public static int[,] AddOne(this IEnumerable<Cell> input, int[,] matrix)
    {
        foreach (var cell in input)
        {
            matrix[cell.Row, cell.Column]++;
        }

        return matrix;
    }

    public static int[,] AddOne(this int[,] input)
    {
        for(var i = 0; i < input.GetLength(0); i++)
        {
            for (var j = 0; j < input.GetLength(1); j++)
            {
                input[i, j]++;
            }
        }

        return input;
    }    
}

public record struct Cell
{
    public int Row;
    public int Column;
}