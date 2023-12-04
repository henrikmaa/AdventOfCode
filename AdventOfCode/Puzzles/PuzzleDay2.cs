using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles;

public class PuzzleDay2 : Puzzle
{
    public PuzzleDay2(string input) : base(input)
    {
    }

    public override string Part1()
    {
        var lines = SplitInputLines();
        var sumOfGameIds = 0;
        foreach (var line in lines)
        {
            var sets = SplitSets(line);
            var isValid = sets.All(set => set.All(IsPairValid));

            if (isValid) sumOfGameIds += GetGameId(line);
        }

        return $"{sumOfGameIds}";
    }

    public override string Part2()
    {
        var lines = SplitInputLines();
        var totalPowerSum = 0;

        foreach (var line in lines)
        {
            var sets = SplitSets(line);
            var minRed = 0;
            var minGreen = 0;
            var minBlue = 0;

            foreach (var set in sets)
            {
                if (set.ContainsKey("red")) minRed = Math.Max(minRed, set["red"]);
                if (set.ContainsKey("green")) minGreen = Math.Max(minGreen, set["green"]);
                if (set.ContainsKey("blue")) minBlue = Math.Max(minBlue, set["blue"]);
            }

            var gamePower = minRed * minGreen * minBlue;
            totalPowerSum += gamePower;
        }

        return $"{totalPowerSum}";
    }

    private IEnumerable<string> SplitInputLines()
    {
        var input = GetInput();

        var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        return lines.ToList();
    }

    private static IEnumerable<Dictionary<string, int>> SplitSets(string input)
    {
        var match = Regex.Match(input, @"Game \d+: (.+)");
        if (!match.Success) return new List<Dictionary<string, int>>();

        var sets = match.Groups[1].Value.Split(';')
            .Select(s => s.Trim())
            .Where(s => !string.IsNullOrEmpty(s));

        var formattedSets = new List<Dictionary<string, int>>();

        foreach (var set in sets)
        {
            var pairs = set.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var setDict = new Dictionary<string, int>();

            for (var i = 0; i < pairs.Length; i += 2)
            {
                var count = int.Parse(pairs[i]);
                var color = pairs[i + 1];
                setDict[color] = count;
            }

            formattedSets.Add(setDict);
        }

        return formattedSets;
    }

    private static int GetGameId(string input)
    {
        var match = Regex.Match(input, @"Game (\d+):");
        if (match.Success && int.TryParse(match.Groups[1].Value, out var gameId)) return gameId;

        return 0;
    }

    private static bool IsPairValid(KeyValuePair<string, int> pair)
    {
        return (pair.Key == "red" && pair.Value <= 12) ||
               (pair.Key == "green" && pair.Value <= 13) ||
               (pair.Key == "blue" && pair.Value <= 14);
    }
}