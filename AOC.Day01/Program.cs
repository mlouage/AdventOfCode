var input = await File.ReadAllTextAsync("Data\\day01_input.txt");
IList<int> depths = input.Trim().Split('\n').Select(e => int.Parse(e.Trim())).ToList();


int count = 0;

for(int i = 1; i < depths.Count; i++)
{
    if (depths[i] > depths[i - 1])
    {
        count++;
    }
}

Console.WriteLine(count);