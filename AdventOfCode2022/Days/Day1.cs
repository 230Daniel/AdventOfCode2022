namespace AdventOfCode2022.Days;

public class Day1 : Day
{
    public Day1() : base(1) { }

    protected override object PartOne(string[] input)
    {
        var mostCalories = 0;
        var currentCalories = 0;
        foreach (var line in input)
        {
            if (line == "")
            {
                if (currentCalories > mostCalories) mostCalories = currentCalories;
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        return mostCalories;
    }

    protected override object PartTwo(string[] input)
    {
        var mostCalories = new List<int> {0, 0, 0};
        var currentCalories = 0;

        foreach (var line in input)
        {
            if (line == "")
            {
                var minMostCalories = mostCalories.Min();
                if (currentCalories > minMostCalories)
                {
                    mostCalories.Remove(minMostCalories);
                    mostCalories.Add(currentCalories);
                }
                currentCalories = 0;
            }
            else
            {
                currentCalories += int.Parse(line);
            }
        }

        return mostCalories.Sum();
    }
}
