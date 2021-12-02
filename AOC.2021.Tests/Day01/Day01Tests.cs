using Xunit;
using AOC._2021;
using System.IO;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AOC._2021.Tests.Day01;

public class Day01Tests
{
    private readonly ITestOutputHelper _output;

    public Day01Tests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day01\\Data\\day01_input_test.txt");
        var sut = new Days.Day01();

        var actual = sut.Part1(test);

        Assert.Equal(7, actual);

        var input = await File.ReadAllTextAsync("Day01\\Data\\day01_input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 01 (Part 1): {solution}");
    }

    [Fact]
    public async Task Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day01\\Data\\day01_input_test.txt");
        var sut = new Days.Day01();

        var actual = sut.Part2(test);

        Assert.Equal(5, actual);

        var input = await File.ReadAllTextAsync("Day01\\Data\\day01_input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 01 (Part 2): {solution}");
    }
}
