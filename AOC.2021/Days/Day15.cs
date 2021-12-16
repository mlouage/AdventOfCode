using static AOC._2021.Days.Day15;
namespace AOC._2021.Days;

using System.Linq;
using Grid = Dictionary<(int, int), Cell>;

public class Day15
{
    public int Part1(string[] input)
    {
        var grid = Parse(input);
        var end = grid.Last().Value;

        return CreateShortestPath(grid, end);
    }

    public int Part2(string[] input)
    {
        var width = input.Length;
        var grid = Parse(input);

        var biggerGrid =
            Enumerable.Range(0, 5).SelectMany(i =>
                Enumerable.Range(0, 5).SelectMany(j =>
                    grid.Select(kvp =>
                    {
                        (int row, int column) newKey = (kvp.Key.Item1 + width * i, kvp.Key.Item2 + width * j);
                        var newRisk = (kvp.Value.Risk + i + j - 1) % 9 + 1;
                        return (newKey, new Cell { Row = newKey.row, Column = newKey.column, Risk = newRisk });
                    })))
            .ToDictionary(tuple => tuple.Item1, tuple => tuple.Item2);
        
        var end = biggerGrid.Last().Value;

        return CreateShortestPath(biggerGrid, end);
    }

    private readonly (int, int)[] adjacent = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

    private static Grid Parse(string[] input)
    {
        Grid cells = new();

        for(int i = 0; i < input.Length; i++)
        {
            var line = input[i];

            for(int j = 0; j < line.Length; j++)
            {
                cells.Add((i, j), new Cell { Row = i, Column = j, Risk = int.Parse(line[j].ToString()) });
            }
        }

        return cells;
    }   

    private int CreateShortestPath(Grid grid, Cell end)
    {
        var next = new PriorityQueue<Cell, int>();
        grid[(0, 0)].Distance = 0;
        next.Enqueue(grid[(0, 0)], 0);
        while (next.Count > 0)
        {
            var current = next.Dequeue();
            if (current.Visited)
            {
                continue;
            }

            current.Visited = true;

            if (current == end)
            {
                return end.Distance;
            }

            var neighbors = new List<Cell>();

            foreach ((int i, int j) in adjacent)
            {
                var key = (current.Row + i, current.Column + j);
                if (grid.ContainsKey(key) && !grid[key].Visited)
                {
                    neighbors.Add(grid[key]);
                }
            }            

            for (int i = 0; i < neighbors.Count; i++)
            {
                var neighbor = neighbors[i];

                var priority = current.Distance + neighbor.Risk;
                if (priority < neighbor.Distance)
                {
                    neighbor.Distance = priority;
                }

                if (neighbor.Distance != int.MaxValue)
                {
                    next.Enqueue(neighbor, neighbor.Distance);
                }
            }
        }
        return end.Distance;
    }

    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Risk { get; set; }
        public int Distance { get; set; } = int.MaxValue;
        public bool Visited { get; set; } = false;        
    }
}
