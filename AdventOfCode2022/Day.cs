namespace AdventOfCode2022;

public abstract class Day
{
    public int DayNumber { get; }

    protected Day(int dayNumber)
    {
        DayNumber = dayNumber;
    }

    public object PartOne()
    {
        var input = GetInput();
        return PartOne(input);
    }

    public object PartTwo()
    {
        var input = GetInput();
        return PartTwo(input);
    }

    protected virtual object PartOne(string[] input)
    {
        return "Not Implemented";
    }

    protected virtual object PartTwo(string[] input)
    {
        return "Not Implemented";
    }

    private string[] GetInput()
    {
        return File.ReadAllLines($"Input/{DayNumber}.txt");
    }
}
