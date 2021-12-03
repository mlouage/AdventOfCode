using Xunit;
using System.IO;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace AOC._2021.Tests;

public class Tests
{
    private readonly ITestOutputHelper _output;

    public Tests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public async Task Day01Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day01\\test.txt");
        var sut = new Days.Day01();

        var actual = sut.Part1(test);

        Assert.Equal(7, actual);

        var input = await File.ReadAllTextAsync("Day01\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 01 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day01Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day01\\test.txt");
        var sut = new Days.Day01();

        var actual = sut.Part2(test);

        Assert.Equal(5, actual);

        var input = await File.ReadAllTextAsync("Day01\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 01 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day02Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day02\\test.txt");
        var sut = new Days.Day02();

        var actual = sut.Part1(test);

        Assert.Equal(150, actual);

        var input = await File.ReadAllTextAsync("Day02\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 02 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day02Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day02\\test.txt");
        var sut = new Days.Day02();

        var actual = sut.Part2(test);

        Assert.Equal(900, actual);

        var input = await File.ReadAllTextAsync("Day02\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 02 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day03Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day03\\test.txt");
        var sut = new Days.Day03();

        var actual = sut.Part1(test);

        Assert.Equal(198, actual);

        var input = await File.ReadAllTextAsync("Day03\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 03 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day03Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day03\\test.txt");
        var sut = new Days.Day03();

        var actual = sut.Part2(test);

        Assert.Equal(230, actual);

        var input = await File.ReadAllTextAsync("Day03\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 03 (Part 2): {solution}");
    }
}
