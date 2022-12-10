namespace AdventOfCode2022.Days;

public class Day6 : Day
{
    public Day6() : base(6) { }

    protected override object PartOne(string[] input)
    {
        var recents = new Queue<char>(4);
        for(var i = 0; i < input[0].Length; i++)
        {
            var character = input[0][i];

            if(recents.Count == 4)
                recents.Dequeue();

            recents.Enqueue(character);

            if (recents.Distinct().Count() == 4)
            {
                return i + 1;
            }
        }

        return -1;
    }

    protected override object PartTwo(string[] input)
    {
        var recents = new Queue<char>(14);
        for(var i = 0; i < input[0].Length; i++)
        {
            var character = input[0][i];

            if(recents.Count == 14)
                recents.Dequeue();

            recents.Enqueue(character);

            if (recents.Distinct().Count() == 14)
            {
                return i + 1;
            }
        }

        return -1;
    }
}
