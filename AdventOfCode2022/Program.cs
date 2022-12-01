using AdventOfCode2022;
using System.Reflection;

var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();
var dayTypes = types.Where(x => x.IsSubclassOf(typeof(Day)) && !x.IsAbstract);
var days = new Dictionary<int, Day>();

foreach (var dayType in dayTypes)
{
    var day = (Day?) Activator.CreateInstance(dayType);

    if (day is null)
    {
        Console.WriteLine($"Failed to create instance of type {dayType.FullName}");
        continue;
    }

    days.Add(day.DayNumber, day);
}

var availableDayNumbers = days.Keys.ToArray();
Array.Sort(availableDayNumbers);
var availableDayNumbersString = string.Join(", ", availableDayNumbers);

while (true)
{
    Console.Write("Advent of Code 2022\n" +
                      "===================\n\n" +
                      $"Enter day number ({availableDayNumbersString})\n" +
                      "> ");

    var input = Console.ReadLine();
    if (!int.TryParse(input, out var dayNumber)) continue;
    if (!days.TryGetValue(dayNumber, out var day)) continue;

    Console.Clear();
    Console.WriteLine($"Running day {dayNumber} part 1...");
    var output = day.PartOne();
    Console.WriteLine($"Answer: {output}\n\n");

    Console.WriteLine($"Running day {dayNumber} part 2...");
    output = day.PartTwo();
    Console.WriteLine($"Answer: {output}\n\n");

    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
