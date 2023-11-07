using System;
using System.IO;
using System.Threading.Tasks;

namespace AdventOfCode;

public abstract class AdventureOfCode 
{
    private static string SessionToken;
    private static InputFetcher InputFetcher;

    public static async Task Main(string[] args)
    {
        SessionToken = await File.ReadAllTextAsync("session.txt");
        InputFetcher = new InputFetcher(SessionToken);
        
        var puzzles = new Puzzle[]
        {
            new PuzzleDay1(await InputFetcher.FetchPuzzleInputAsync(2022, 1)),
        }; 
        
        for (int i = 0; i < puzzles.Length; i++)
        {
            var day = (i + 1).ToString();
            Console.WriteLine($"Day {day} | Part 1: {puzzles[i].Part1()}");
            Console.WriteLine($"Day {day} | Part 2: {puzzles[i].Part2()}"); 
        }
    }
}