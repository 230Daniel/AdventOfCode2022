namespace AdventOfCode2022.Days;

public class Day7 : Day
{
    public Day7() : base(7) { }

    protected override object PartOne(string[] input)
    {
        return GetDirectories(input).Values.Where(x => x <= 100000).Sum();
    }

    protected override object PartTwo(string[] input)
    {
        var directories = GetDirectories(input);

        var freeSpace = 70000000 - directories[""];
        var spaceToFreeUp = 30000000 - freeSpace;

        var closestDir = directories.Where(x => x.Value >= spaceToFreeUp).MinBy(x => x.Value);
        return closestDir.Value;
    }

    private static Dictionary<string, int> GetDirectories(string[] input)
    {
        var directories = new Dictionary<string, int>();
        var currentDirectories = new Stack<string>();

        directories[""] = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];

            if (line == "$ cd /")
            {
                currentDirectories.Clear();
                currentDirectories.Push("");
            }
            else if (line.StartsWith("$ cd"))
            {
                var directory = line.Split()[2];
                if (directory == "..")
                {
                    currentDirectories.Pop();
                }
                else
                {
                    currentDirectories.Push(directory);
                    var fullDirectory = string.Join("/", currentDirectories.Reverse());
                    if (!directories.ContainsKey(fullDirectory))
                        directories[fullDirectory] = 0;
                }
            }
            else if (line == "$ ls")
            {
                var list = input.Skip(i + 1).TakeWhile(x => !x.StartsWith("$"));
                i += list.Count();

                foreach (var listItem in list)
                {
                    var partOne = listItem.Split()[0];
                    var partTwo = listItem.Split()[1];

                    if (partOne == "dir")
                    {
                        var fullDirectory = string.Join("/", currentDirectories.Reverse()) + partTwo;
                        if (!directories.ContainsKey(fullDirectory))
                            directories[fullDirectory] = 0;
                    }
                    else
                    {
                        var fullDirectory = "";
                        foreach (var directory in currentDirectories.Reverse())
                        {
                            if(directory != "")
                                fullDirectory += "/" + directory;
                            directories[fullDirectory] += int.Parse(partOne);
                        }
                    }
                }
            }
        }

        return directories;
    }
}
