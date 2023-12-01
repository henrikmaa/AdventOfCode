namespace AdventOfCode;

public class PuzzleDay1 : Puzzle
{
    public PuzzleDay1(string input) : base(input)
    {
    }

    public override string Part1()
    {
        var lines = SplitInputLines();
        var calibrationValue = 0;

        foreach (var line in lines) calibrationValue += ExtractNumbersOnly(line);
        return $"{calibrationValue}";
    }

    public override string Part2()
    {
        var lines = SplitInputLines();
        var calibrationValue = 0;

        foreach (var line in lines) calibrationValue += ExtractNumbersWithStringRepresentation(line);
        return $"{calibrationValue}";
    }

    private List<string> SplitInputLines()
    {
        var input = GetInput();
        var splittedList = new List<string>();

        var lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        foreach (var line in lines) splittedList.Add(line);

        return splittedList;
    }

    private static int ExtractNumbersOnly(string input)
    {
        var digits = input.Where(char.IsDigit).Select(c => c - '0').ToList();

        if (!digits.Any()) return 0;

        return digits.First() * 10 + digits.Last();
    }

    private static int ExtractNumbersWithStringRepresentation(string input)
    {
        var numericInputString = ConvertStringNumbersToNumericWeird(input);
        var numericValuesOnly = ExtractNumbersOnly(numericInputString);
        return numericValuesOnly;
    }

    private static string ConvertStringNumbersToNumericWeird(string input)
    {
        // Because a string can be e.g "twone" add back the start and ending of string to be able to extract both numbers
        // E.g 1 and 2 in this case. If not it would only get two and not one.
        input = input
            .Replace("one", "o1e")
            .Replace("two", "t2o")
            .Replace("three", "t3e")
            .Replace("four", "f4r")
            .Replace("five", "f5e")
            .Replace("six", "s6x")
            .Replace("seven", "s7n")
            .Replace("eight", "e8t")
            .Replace("nine", "n9e");

        return input;
    }
}