using Xunit;
using System.IO;
using System.Threading.Tasks;
using Xunit.Abstractions;
using AOC._2021.Days;

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
        var test = await File.ReadAllTextAsync("Day06\\test.txt");
        var sut = new Days.Day06();

        var actual = sut.Part1(test);

        Assert.Equal(5934, actual); // after 80 days

        var input = await File.ReadAllTextAsync("Day06\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 06 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day06Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day06\\test.txt");
        var sut = new Days.Day06();

        var actual = sut.Part2(test);

        Assert.Equal(26984457539, actual);

        var input = await File.ReadAllTextAsync("Day06\\input.txt");
        var solution = sut.Part2(input);


        _output.WriteLine($"Day 06 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day07Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day07\\test.txt");
        var sut = new Days.Day07();

        var actual = sut.Part1(test);

        Assert.Equal(37, actual);

        var input = await File.ReadAllTextAsync("Day07\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 07 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day07Part2Test()
    {
        var test = await File.ReadAllTextAsync("Day07\\test.txt");
        var sut = new Days.Day07();

        //var actual = sut.Part2(test);

        //Assert.Equal(168, actual);

        var input = await File.ReadAllTextAsync("Day07\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 07 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day08Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day08\\test.txt");
        var sut = new Days.Day08();

        var actual = sut.Part1(test);

        Assert.Equal(26, actual);

        var input = await File.ReadAllLinesAsync("Day08\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 08 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day08Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day08\\test.txt");
        var sut = new Days.Day08();

        var actual = sut.Part2(test);

        Assert.Equal(61229, actual);

        var input = await File.ReadAllLinesAsync("Day08\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 08 (Part 2): {solution}");
    }

    [Theory]
    [InlineData('b', true)]
    [InlineData('s', false)]
    public void Day08ExtensionsInTest(char input, bool expected)
    {
        var collection = "abcdef".ToCharArray();       

        var actual = input.In(collection);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new[] { 'd', 'e', 'f', 'a', 'b', 'c' }, true)]
    [InlineData(new[] { 'd', 'e', 'f', 'a', 'b', 'g' }, false)]
    public void Day08ExtensionsAllInTest(char[] input, bool expected)
    {
        var collection = "abcdef".ToCharArray();

        var actual = input.AllIn(collection);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task Day09Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day09\\test.txt");
        var sut = new Days.Day09();

        var actual = sut.Part1(test);

        Assert.Equal(15, actual);

        var input = await File.ReadAllLinesAsync("Day09\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 09 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day09Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day09\\test.txt");
        var sut = new Days.Day09();

        var actual = sut.Part2(test);

        Assert.Equal(1134, actual);

        var input = await File.ReadAllLinesAsync("Day09\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 09 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day10Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day10\\test.txt");
        var sut = new Days.Day10();

        var actual = sut.Part1(test);

        Assert.Equal(26397, actual);

        var input = await File.ReadAllLinesAsync("Day10\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 10 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day10Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day10\\test.txt");
        var sut = new Days.Day10();

        var actual = sut.Part2(test);

        Assert.Equal(288957, actual);

        var input = await File.ReadAllLinesAsync("Day10\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 10 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day11Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day11\\test.txt");
        var sut = new Days.Day11();

        var actual = sut.Part1(test, 100);

        Assert.Equal(1656, actual);

        var input = await File.ReadAllLinesAsync("Day11\\input.txt");
        var solution = sut.Part1(input, 100);

        _output.WriteLine($"Day 11 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day11Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day11\\test.txt");
        var sut = new Days.Day11();

        var actual = sut.Part2(test, 1000);

        Assert.Equal(195, actual);

        var input = await File.ReadAllLinesAsync("Day11\\input.txt");
        var solution = sut.Part2(input, 1000);

        _output.WriteLine($"Day 11 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day12Part1Test()
    {
        var test = await File.ReadAllLinesAsync("Day12\\test.txt");
        var sut = new Days.Day12();

        var actual = sut.Part1(test);

        Assert.Equal(19, actual);

        var input = await File.ReadAllLinesAsync("Day12\\input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 12 (Part 1): {solution}");
    }

    [Fact]
    public async Task Day12Part2Test()
    {
        var test = await File.ReadAllLinesAsync("Day12\\test.txt");
        var sut = new Days.Day12();

        var actual = sut.Part2(test);

        Assert.Equal(103, actual);

        var input = await File.ReadAllLinesAsync("Day12\\input.txt");
        var solution = sut.Part2(input);

        _output.WriteLine($"Day 12 (Part 2): {solution}");
    }

    [Fact]
    public async Task Day13Part1Test()
    {
        var test = await File.ReadAllTextAsync("Day13/test.txt");
        var sut = new Days.Day13();

        var actual = sut.Part1(test);

        Assert.Equal(17, actual);

        var input = await File.ReadAllTextAsync("Day13/input.txt");
        var solution = sut.Part1(input);

        _output.WriteLine($"Day 13 (Part 1): {solution}");
    }
    
    [Fact]
    public async Task Day13Part2Test()
    {
        var sut = new Days.Day13();
        var input = await File.ReadAllTextAsync("Day13/input.txt");
        var solution = sut.Part2(input);
        
        _output.WriteLine($"Day 13 (Part 2)");

        
        
    }
}
