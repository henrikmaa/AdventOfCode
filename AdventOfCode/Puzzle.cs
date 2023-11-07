namespace AdventOfCode;

public abstract class Puzzle
{
    private readonly string _input;

    protected Puzzle(string input)
    {
        _input = input;
    }

    public string GetInput()
    {
        return _input;
    }

    public abstract string Part1();

    public abstract string Part2();

}