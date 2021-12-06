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

    [Fact]
    public async Task Day04Part1Test()
    {
        var test_numbers = await File.ReadAllTextAsync("Day04\\test_numbers.txt");
        var test_input = await File.ReadAllLinesAsync("Day04\\test_input.txt");
        var sut = new Days.Day04();

        var actual = sut.Part1(test_numbers, test_input);

        Assert.Equal(4512, actual);

        var numbers = await File.ReadAllTextAsync("Day04\\numbers.txt");
        var input = await File.ReadAllLinesAsync("Day04\\input.txt");
        var solution = sut.Part1(numbers, input);

        _output.WriteLine($"Day 04 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day04Part2Test()
    {
        var test_numbers = await File.ReadAllTextAsync("Day04\\test_numbers.txt");
        var test_input = await File.ReadAllLinesAsync("Day04\\test_input.txt");
        var sut = new Days.Day04();

        var actual = sut.Part2(test_numbers, test_input);

        Assert.Equal(1924, actual);

        var numbers = await File.ReadAllTextAsync("Day04\\numbers.txt");
        var input = await File.ReadAllLinesAsync("Day04\\input.txt");
        var solution = sut.Part2(numbers, input);

        _output.WriteLine($"Day 04 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day05Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day05\\test.txt");
        var sut = new Days.Day05();

        var actual = sut.Part1(test);

        Assert.Equal(5, actual);

        var input = await File.ReadAllLinesAsync("Day05\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 05 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day05Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day05\\test.txt");
        var sut = new Days.Day05();

        var actual = sut.Part2(test);

        Assert.Equal(12, actual);

        var input = await File.ReadAllLinesAsync("Day05\\input.txt");
        var solution = sut.Part2(input);

     
        _output.WriteLine($"Day 05 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day06Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day06\\test.txt");
        var sut = new Days.Day06();

        var actual = sut.Part1(test);

        Assert.Equal(5934, actual); // after 80 days

        var input = await File.ReadAllLinesAsync("Day06\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 06 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day06Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day06\\test.txt");
        var sut = new Days.Day05();

        var actual = sut.Part2(test);

        Assert.Equal(0, actual);

        var input = await File.ReadAllLinesAsync("Day06\\input.txt");
        var solution = sut.Part2(input);


        _output.WriteLine($"Day 06 (Part 2): {solution}");
    }
}
