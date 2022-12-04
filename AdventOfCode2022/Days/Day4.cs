namespace AdventOfCode2022.Days;

public class Day4 : Day
{
    public Day4() : base(4) { }

    protected override object PartOne(string[] input)
    {
        var count = 0;

        foreach (var line in input)
        {
            var sectionStrings = line.Split(',');
            var sectionOneStrings = sectionStrings[0].Split('-');
            var sectionTwoStrings = sectionStrings[1].Split('-');

            var sectionOneStart = int.Parse(sectionOneStrings[0]);
            var sectionOneEnd = int.Parse(sectionOneStrings[1]);
            var sectionTwoStart = int.Parse(sectionTwoStrings[0]);
            var sectionTwoEnd = int.Parse(sectionTwoStrings[1]);

            if (sectionOneStart <= sectionTwoStart && sectionOneEnd >= sectionTwoEnd ||
                sectionTwoStart <= sectionOneStart && sectionTwoEnd >= sectionOneEnd)
                count++;
        }

        return count;
    }

    protected override object PartTwo(string[] input)
    {
        var count = 0;

        foreach (var line in input)
        {
            var sectionStrings = line.Split(',');
            var sectionOneStrings = sectionStrings[0].Split('-');
            var sectionTwoStrings = sectionStrings[1].Split('-');

            var sectionOneStart = int.Parse(sectionOneStrings[0]);
            var sectionOneEnd = int.Parse(sectionOneStrings[1]);
            var sectionTwoStart = int.Parse(sectionTwoStrings[0]);
            var sectionTwoEnd = int.Parse(sectionTwoStrings[1]);

            if (sectionOneStart <= sectionTwoStart && sectionOneEnd >= sectionTwoStart ||
                sectionOneStart <= sectionTwoEnd && sectionOneEnd >= sectionTwoEnd ||
                sectionTwoStart <= sectionOneStart && sectionTwoEnd >= sectionOneStart ||
                sectionTwoStart <= sectionOneEnd && sectionTwoEnd >= sectionOneEnd)
                count++;
        }

        return count;
    }
}
