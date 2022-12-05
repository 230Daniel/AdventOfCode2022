namespace AdventOfCode2022.Days;

public class Day5 : Day
{
    public Day5() : base(5) { }

    protected override object PartOne(string[] input)
    {
        var stackDict = new Dictionary<int, List<char>>();
        foreach (var line in input)
        {
            if (line[1] == '1') break;

            var stackNumber = 1;
            for (var i = 1; i < line.Length; i += 4)
            {
                if (line[i] != ' ')
                {
                    if (!stackDict.TryGetValue(stackNumber, out var stack))
                    {
                        stack = new List<char>();
                        stackDict[stackNumber] = stack;
                    }

                    stack.Add(line[i]);
                }
                stackNumber++;
            }
        }

        var startOfMoves = Array.IndexOf(input, "") + 1;
        foreach (var line in input.Skip(startOfMoves))
        {
            var numbers = new List<int>();
            foreach (var word in line.Split(' '))
            {
                if (int.TryParse(word, out var number))
                    numbers.Add(number);
            }

            var amount = numbers[0];
            var source = stackDict[numbers[1]];
            var dest = stackDict[numbers[2]];

            for (var i = 0; i < amount; i++)
            {
                var item = source[0];
                source.RemoveAt(0);
                dest.Insert(0, item);
            }
        }

        var msg = "";
        for (var i = 1; i <= stackDict.Keys.Max(); i++)
        {
            msg += stackDict[i][0];
        }

        return msg;
    }

    protected override object PartTwo(string[] input)
    {
        var stackDict = new Dictionary<int, List<char>>();
        foreach (var line in input)
        {
            if (line[1] == '1') break;

            var stackNumber = 1;
            for (var i = 1; i < line.Length; i += 4)
            {
                if (line[i] != ' ')
                {
                    if (!stackDict.TryGetValue(stackNumber, out var stack))
                    {
                        stack = new List<char>();
                        stackDict[stackNumber] = stack;
                    }

                    stack.Add(line[i]);
                }
                stackNumber++;
            }
        }

        var startOfMoves = Array.IndexOf(input, "") + 1;
        foreach (var line in input.Skip(startOfMoves))
        {
            var numbers = new List<int>();
            foreach (var word in line.Split(' '))
            {
                if (int.TryParse(word, out var number))
                    numbers.Add(number);
            }

            var amount = numbers[0];
            var source = stackDict[numbers[1]];
            var dest = stackDict[numbers[2]];

            for (var i = amount - 1; i >= 0; i--)
            {
                var item = source[i];
                source.RemoveAt(i);
                dest.Insert(0, item);
            }
        }

        var msg = "";
        for (var i = 1; i <= stackDict.Keys.Max(); i++)
        {
            msg += stackDict[i][0];
        }

        return msg;
    }
}
