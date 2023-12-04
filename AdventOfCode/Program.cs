using AdventOfCode.Puzzles;

namespace AdventOfCode;

public abstract class AdventureOfCode
{
    private static string? _sessionToken;
    private static InputFetcher? _inputFetcher;

    public static async Task Main(string[] args)
    {
        _sessionToken = await File.ReadAllTextAsync("session.txt");
        _inputFetcher = new InputFetcher(_sessionToken);

        var puzzles = new Puzzle[]
        {
            new PuzzleDay1(await _inputFetcher.FetchPuzzleInputAsync(2023, 1)),
            new PuzzleDay2(await _inputFetcher.FetchPuzzleInputAsync(2023, 2))
        };

        for (var i = 0; i < puzzles.Length; i++)
        {
            var day = (i + 1).ToString();
            Console.WriteLine($"Day {day} | Part 1: {puzzles[i].Part1()}");
            Console.WriteLine($"Day {day} | Part 2: {puzzles[i].Part2()}");
        }
    }
}