namespace AOC._2021.Days;

public class Day10
{
    public int Part1(string[] input)
    {
        var chunks = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' }
        };
        var openingChunks = new char[]{ '(', '[', '{', '<' };
        var result = new Queue<char>();
        var corrupted = false;

        for (int i = 0; i < input.Length; i++)
        {
            var closingStack = new Stack<char>();
            var line = input[i];

            for (int j = 0; j < line.Length; j++)
            {
                var chunk = line[j];
                var validNextChunks = new List<char>();
                
                if (openingChunks.Contains(chunk))
                {
                    var correspondingClosingChunk = chunks[chunk];
                    closingStack.Push(correspondingClosingChunk);
                    
                    validNextChunks.AddRange(openingChunks);
                    validNextChunks.Add(correspondingClosingChunk);
                }
                else
                {                    
                    var validClosingChunk = closingStack.Pop();
                    validNextChunks.Add(validClosingChunk);
                    validNextChunks.AddRange(openingChunks);
                }
                
                var next = line[j];

                if (validNextChunks.Contains(next))
                {
                    continue;
                }
                else
                {
                    corrupted = true;
                    result.Enqueue(chunk);
                    break;
                }
            }

            if (corrupted)
            {                
                corrupted = false;
            }
        }

        var sum = 0;

        while(result.Any())
        {
            var item = result.Dequeue();

            if (item == ')') sum += 3;
            if (item == ']') sum += 57;
            if (item == '}') sum += 1197;
            if (item == '>') sum += 25137;
        }

        return sum;
    }

    public long Part2(string[] input)
    {
        var chunks = new Dictionary<char, char>()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' }
        };
        var openingChunks = new char[] { '(', '[', '{', '<' };
        var result = new Queue<char>();
        var corrupted = false;
        var lineSums = new List<long>();

        for (int i = 0; i < input.Length; i++)
        {
            var closingStack = new Stack<char>();
            var line = input[i];

            for (int j = 0; j < line.Length; j++)
            {
                var chunk = line[j];
                var validNextChunks = new List<char>();

                if (openingChunks.Contains(chunk))
                {
                    var correspondingClosingChunk = chunks[chunk];
                    closingStack.Push(correspondingClosingChunk);

                    validNextChunks.AddRange(openingChunks);
                    validNextChunks.Add(correspondingClosingChunk);
                }
                else
                {
                    var validClosingChunk = closingStack.Pop();
                    validNextChunks.Add(validClosingChunk);
                    validNextChunks.AddRange(openingChunks);
                }

                var next = line[j];

                if (validNextChunks.Contains(next))
                {
                    continue;
                }
                else
                {
                    corrupted = true;
                    result.Enqueue(chunk);
                    break;
                }
            }

            if (corrupted)
            {
                corrupted = false;
            }
            else
            {
                var lineSum = 0L;

                while (closingStack.Any())
                {
                    var item = closingStack.Pop();
                    var points = 0;

                    if (item == ')') points = 1;
                    if (item == ']') points = 2;
                    if (item == '}') points = 3;
                    if (item == '>') points = 4;

                    lineSum = lineSum * 5 + points;
                }

                lineSums.Add(lineSum);
            }
        }

        var orderedLineSums = lineSums.OrderBy(x => x).ToList();
        var index = (orderedLineSums.Count / 2);

        return orderedLineSums[index];
    }
}

