namespace AdventOfCode;

public class PuzzleDay1 : Puzzle
{
    public PuzzleDay1(string input) : base(input)
    {
    } 
    public override string Part1()
    {

        var sums = GetCaloriesAmounts();
        
        var mostCalories = sums.OrderByDescending(n => n).Take(1).ToList();
        
        return $"{mostCalories[0]}";
    }

    public override string Part2()
    {
        var sums = GetCaloriesAmounts();
        
        var topThree = sums.OrderByDescending(n => n).Take(3).ToList();

        var topThreeTotal = topThree[0] + topThree[1] + topThree[2];
        return $"{topThreeTotal}";
    }

    public List<int> GetCaloriesAmounts()
    {
        

        var input = GetInput();
        
        string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

        List<int> sums = new List<int>();
        int currentSum = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                if (currentSum > 0)
                {
                    sums.Add(currentSum);
                    currentSum = 0;
                }
            }
            else
            {
                if (int.TryParse(line, out int number))
                {
                    currentSum += number;
                }
            }
        }
        
        if (currentSum > 0)
        {
            sums.Add(currentSum);
        }

        return sums;
    }
}

