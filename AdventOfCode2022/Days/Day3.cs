namespace AdventOfCode2022.Days;

public class Day3 : Day
{
    public Day3() : base(3) { }

    protected override object PartOne(string[] input)
    {
        var prioritySum = 0;

        foreach (var line in input)
        {
            var compartmentSize = line.Length / 2;
            var firstCompartment = new char[compartmentSize];

            for (var i = 0; i < compartmentSize; i++)
            {
                firstCompartment[i] = line[i];
            }

            char sharedItem = default;
            for (var i = 0; i < compartmentSize; i++)
            {
                var item = line[compartmentSize + i];
                if (firstCompartment.Contains(item))
                {
                    sharedItem = item;
                    break;
                }
            }

            prioritySum += GetPriority(sharedItem);
        }

        return prioritySum;
    }

    protected override object PartTwo(string[] input)
    {
        var prioritySum = 0;

        for(var i = 0; i < input.Length; i += 3)
        {
            var commonItems = input[i].ToCharArray().ToList();
            for (var j = 1; j < 3; j++)
            {
                var rucksack = input[i + j];
                commonItems.RemoveAll(item => !rucksack.Contains(item));
            }

            prioritySum += GetPriority(commonItems[0]);
        }

        return prioritySum;
    }

    private static int GetPriority(char itemType)
    {
        if (itemType is >= 'a' and <= 'z')
        {
            return itemType - 'a' + 1;
        }

        return itemType - 'A' + 27;
    }
}
