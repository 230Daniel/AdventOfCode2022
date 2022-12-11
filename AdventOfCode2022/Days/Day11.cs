using System.Numerics;

namespace AdventOfCode2022.Days;

public class Day11 : Day
{
    public Day11() : base(11) { }

    protected override object PartOne(string[] input)
    {
        var monkeys = ParseMonkeys(input);

        for (var i = 0; i < 20; i++)
        {
            Console.WriteLine(i);
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items.ToArray())
                {
                    monkey.Inspections += 1;
                    var operandOne = monkey.OperandOne ?? item;
                    var operandTwo = monkey.OperandTwo ?? item;
                    var result = monkey.Operation switch
                    {
                        "*" => operandOne * operandTwo,
                        "+" => operandOne + operandTwo,
                        "-" => operandOne - operandTwo,
                        "/" => operandOne / operandTwo,
                        _ => throw new Exception($"Unknown operand {monkey.Operation}")
                    };

                    result /= 3;
                    var targetMonkey = monkeys[result % monkey.Test == 0 ? monkey.MonkeyIfTrue : monkey.MonkeyIfFalse];

                    targetMonkey.Items.Add(result);
                    monkey.Items.Remove(item);
                }
            }
        }

        var mostActiveMonkeys = monkeys.OrderByDescending(x => x.Inspections).ToArray();
        return mostActiveMonkeys[0].Inspections * mostActiveMonkeys[1].Inspections;
    }

    protected override object PartTwo(string[] input)
    {
        var monkeys = ParseMonkeys(input);

        var p = 1;
        foreach (var monkey in monkeys)
        {
            p *= monkey.Test;
        }
        Console.WriteLine($"P: {p}");

        for (var i = 0; i < 10000; i++)
        {
            // Console.WriteLine(i);
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.PartTwoItems.ToArray())
                {
                    monkey.Inspections += 1;
                    var operandOne = monkey.OperandOne ?? item;
                    var operandTwo = monkey.OperandTwo ?? item;
                    var result = monkey.Operation switch
                    {
                        "*" => operandOne * operandTwo,
                        "+" => operandOne + operandTwo,
                        "-" => operandOne - operandTwo,
                        "/" => operandOne / operandTwo,
                        _ => throw new Exception($"Unknown operand {monkey.Operation}")
                    };

                    result %= p;

                    var targetMonkey = monkeys[result % monkey.Test == 0 ? monkey.MonkeyIfTrue : monkey.MonkeyIfFalse];

                    targetMonkey.PartTwoItems.Add(result);
                    monkey.PartTwoItems.Remove(item);
                }
            }
        }

        var mostActiveMonkeys = monkeys.OrderByDescending(x => x.Inspections).ToArray();
        return new BigInteger(mostActiveMonkeys[0].Inspections) * new BigInteger(mostActiveMonkeys[1].Inspections);
    }

    private List<Monkey> ParseMonkeys(string[] input)
    {
        var monkeys = new List<Monkey>();

        Monkey currentMonkey = null;
        foreach (var line in input)
        {
            if (line.StartsWith("Monkey"))
            {
                currentMonkey = new Monkey();
            }
            else if (line.StartsWith("  Starting items:"))
            {
                currentMonkey.Items = new string(line.Skip(18).ToArray()).Split(", ").Select(int.Parse).ToList();
                currentMonkey.PartTwoItems = currentMonkey.Items.Select(x => new BigInteger(x)).ToList();
            }
            else if (line.StartsWith("  Operation:"))
            {
                var operationString = new string(line.Skip(19).ToArray());
                var operandOne = operationString.Split()[0];
                var operandTwo = operationString.Split()[2];

                currentMonkey.OperandOne = operandOne == "old" ? null : int.Parse(operandOne);
                currentMonkey.OperandTwo = operandTwo == "old" ? null : int.Parse(operandTwo);
                currentMonkey.Operation = operationString.Split()[1];
            }
            else if (line.StartsWith("  Test:"))
            {
                currentMonkey.Test = int.Parse(line.Split().Last());
            }
            else if (line.StartsWith("    If true:"))
            {
                currentMonkey.MonkeyIfTrue = int.Parse(line.Split().Last());
            }
            else if (line.StartsWith("    If false:"))
            {
                currentMonkey.MonkeyIfFalse = int.Parse(line.Split().Last());
            }
            else if (string.IsNullOrWhiteSpace(line))
            {
                monkeys.Add(currentMonkey);
            }
        }
        monkeys.Add(currentMonkey);

        return monkeys;
    }

    private class Monkey
    {
        public List<int> Items { get; set; }
        public List<BigInteger> PartTwoItems { get; set; }
        public int? OperandOne { get; set; }
        public int? OperandTwo { get; set; }
        public string Operation { get; set; }
        public int Test { get; set; }
        public int MonkeyIfTrue { get; set; }
        public int MonkeyIfFalse { get; set; }
        public uint Inspections { get; set; }
    }
}
