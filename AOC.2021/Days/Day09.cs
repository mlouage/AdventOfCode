namespace AOC._2021.Days;

public class Day09
{
    private int x = 0;
    private int y = 0;
    private int[,] matrix;

    public int Part1(string[] input)
    {
        var matrix = Parse(input);

        var sum = 0;

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                var adjcentCells = CalculateAdjcentCells(i, j).ToList();
                var currentCell = matrix[i, j];

                if (adjcentCells.All(x => x > currentCell))
                {
                    currentCell++;
                    sum += currentCell;
                }
            }
        }

        return sum;
    }

    public int Part2(string[] input)
    {
        var matrix = Parse(input);
        var lowPoints = new List<Point>();

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                var adjcentCells = CalculateAdjcentCells(i, j).ToList();
                var currentCell = matrix[i, j];

                if (adjcentCells.All(x => x > currentCell))
                {
                    lowPoints.Add(new Point { x = i, y = j });

                    currentCell++;
                }
            }
        }

        var largest = new List<int>();

        foreach (var lowPoint in lowPoints)
        {
            int size = 0;
            var visited = new Queue<Point>();
            var toVisit = new Queue<Point>();

            toVisit.Enqueue(lowPoint);

            while(toVisit.Any())
            {
                var next = toVisit.Dequeue();

                if (visited.Contains(next))
                {
                    continue;
                }

                visited.Enqueue(next);

                var row = next.x;
                var col = next.y;

                if (row - 1 >= 0 && matrix[row - 1, col] != 9)
                {
                    var down = new Point() { x = row - 1, y = col };

                    if (!visited.Contains(down))
                    {
                        toVisit.Enqueue(down);
                    }
                }

                if (row + 1 < x && matrix[row + 1, col] != 9)
                {
                    var up = new Point() { x = row + 1, y = col };
                    
                    if (!visited.Contains(up))
                    {
                        toVisit.Enqueue(up);
                    }
                }

                if (col - 1 >= 0 && matrix[row, col - 1] != 9)
                {
                    var left = new Point() { x = row, y = col - 1 };
                    
                    if (!visited.Contains(left))
                    {
                        toVisit.Enqueue(left);
                    }
                        
                }
                if (col + 1 < y && matrix[row, col + 1] != 9)
                {
                    var right = new Point() { x = row, y = col + 1 };

                    if (!visited.Contains(right))
                    {
                        toVisit.Enqueue(right);
                    }
                }
            }
            largest.Add(visited.Count);
        }

        return largest.OrderByDescending(x => x).Take(3).Aggregate((total, next) => total * next);
    }

    private int[,] Parse(string[] input)
    {
        x = input.Count();
        y = input.First().Count();

        matrix = new int[x, y];

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

    private IEnumerable<int> CalculateAdjcentCells(int i, int j)
    {
        if (i - 1 >= 0) yield return matrix[i - 1, j];
        if (j - 1 >= 0) yield return matrix[i, j - 1];
        if (j + 1 <= y - 1) yield return matrix[i, j + 1];
        if (i + 1 <= x - 1) yield return matrix[i + 1, j];
    }
}

public record struct Point
{
    public int x;
    public int y;
}
