using System.Text.RegularExpressions;

namespace AOC._2021.Days;

public class Day13
{
    public int Part1(string input)
    {
        var (grid, instructions) = Parse(input);

        var instruction = instructions.First();

        var cells = GetCells(grid);

        foreach (var cell in cells)
        {
            if (grid[cell.Row, cell.Column] > 0)
            {
                if (cell.Row > instruction.Row && instruction.Row > 0)
                {
                    grid[cell.Row, cell.Column] = 0;
                    grid[cell.Row - (cell.Row - instruction.Row) * 2, cell.Column] = 1;
                }
                else if (cell.Column > instruction.Column && instruction.Column > 0)
                {
                    grid[cell.Row, cell.Column] = 0;
                    grid[cell.Row, cell.Column - (cell.Column - instruction.Column) * 2] = 1;
                }
            }
        }
        
        return GetCells(grid).Count(cell => grid[cell.Row, cell.Column] == 1);
    }

    public IEnumerable<string> Part2(string input)
    {
        var (grid, instructions) = Parse(input);

        var cells = GetCells(grid).ToList();

        foreach (var instruction in instructions)
        {
            foreach (var cell in cells)
            {
                if (grid[cell.Row, cell.Column] > 0)
                {
                    if (cell.Row > instruction.Row && instruction.Row > 0)
                    {
                        grid[cell.Row, cell.Column] = 0;
                        grid[cell.Row - (cell.Row - instruction.Row) * 2, cell.Column] = 1;
                    }
                    else if (cell.Column > instruction.Column && instruction.Column > 0)
                    {
                        grid[cell.Row, cell.Column] = 0;
                        grid[cell.Row, cell.Column - (cell.Column - instruction.Column) * 2] = 1;
                    }
                }
            }    
        }
        
        return WriteOut(grid, grid.GetLength(0), grid.GetLength(1));
    }
    
    private static (int[,] grid, ICollection<(int Row, int Column)> instructions) Parse(string input)
    {
        var parts = input.Split("\n\n");

        var coordinates = parts[0].Split('\n')
            .Select(line => (
                X: int.Parse(line.Split(',')[0]), 
                Y: int.Parse(line.Split(',')[1]))).ToList();

        var width = coordinates.Max(cell => cell.X) + 1;
        var height = coordinates.Max(cell => cell.Y) + 1;

        var grid = new int[width, height];
        foreach (var cell in coordinates)
        {
            grid[cell.X, cell.Y] = 1;
        }

        var instructions = parts[1].Split('\n').Select(line =>
        {
            var x = Regex.Match(line, @"x=(\d+)");
            var y = Regex.Match(line, @"y=(\d+)");

            return (X: x.Success ? int.Parse(x.Groups[1].Value) : 0, Y: y.Success ? int.Parse(y.Groups[1].Value) : 0);
        }).ToList();

        return (grid, instructions);
    }
    
    private static IEnumerable<Cell> GetCells<T>(T[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                yield return new Cell { Row = i, Column = j };
            }
        }
    }

    public static IEnumerable<string> WriteOut(int[,] matrix, int width, int height)
    {
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                   yield return matrix[x, y] > 0 ? "#" : ".";
                }
            }
    }
    
    public record struct Cell
    {
        public int Row;
        public int Column;
    }
}