namespace AdventOfCode2022.Days;

public class Day2 : Day
{
    public Day2() : base(2) { }

    protected override object PartOne(string[] input)
    {
        var score = 0;

        foreach (var line in input)
        {
            var opponentPlays = GetItemFromCharacter(line[0]);
            var wePlay = GetItemFromCharacter(line[2]);

            score += wePlay;

            if (opponentPlays == wePlay)
            {
                score += 3;
            }
            else
            {
                var itemToWin = opponentPlays + 1;
                if (itemToWin == 4) itemToWin = 1;

                if (wePlay == itemToWin)
                    score += 6;
            }
        }

        return score;
    }

    protected override object PartTwo(string[] input)
    {
        var score = 0;

        foreach (var line in input)
        {
            var opponentPlays = GetItemFromCharacter(line[0]);
            var desiredResult = line[2];

            var itemToPlay = desiredResult switch
            {
                'X' => opponentPlays - 1,
                'Y' => opponentPlays,
                'Z' => opponentPlays + 1,
                _ => 0
            };

            if (itemToPlay == 4) itemToPlay = 1;
            if (itemToPlay == 0) itemToPlay = 3;

            score += itemToPlay;
            score += desiredResult switch
            {
                'X' => 0,
                'Y' => 3,
                'Z' => 6,
                _ => 0
            };
        }

        return score;
    }

    private static int GetItemFromCharacter(char character)
    {
        switch (character)
        {
            case 'A':
            case 'X':
                return 1;
            case 'B':
            case 'Y':
                return 2;
            case 'C':
            case 'Z':
                return 3;
            default:
                throw new ArgumentOutOfRangeException(nameof(character));
        }
    }
}
