namespace AdventOfCode;

public class Day03 : BaseDay
{
    private readonly List<string> _input;
    private readonly List<List<int>> _inputList = [];


    public Day03()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
        ProcessInput();
    }

    private void ProcessInput()
    {
        foreach (var line in _input)
        {
            var chars = line.ToCharArray();
            var lineList = chars.Select(c => int.Parse(c.ToString())).ToList();
            _inputList.Add(lineList);
        }
    }

    private long ProcessPartOne()
    {
        var totalJoltage = 0L;


        foreach (var line in _inputList)
        {
            var indexOfMax = FindMaxIndex(line, 0, line.Count - 1);
            var nextMaxIndex = FindMaxIndex(line, indexOfMax+1, line.Count);

            totalJoltage += long.Parse($"{line[indexOfMax]}{line[nextMaxIndex]}");
        }
        
        return totalJoltage;
    }

    private long ProcessPartTwo()
    {
        var totalJoltage = 0L;

        foreach (var line in _inputList)
        {
            var lastIndex = 0;
            var joltage = "";
            for (var remaining = 12; remaining > 0; remaining--)
            {
               var currentMaxIndex = FindMaxIndex(line, lastIndex, line.Count - remaining + 1);
               joltage += $"{line[currentMaxIndex]}";
               lastIndex = currentMaxIndex + 1;
            }
            
            totalJoltage += long.Parse(joltage);
        }
        
        
        return totalJoltage;
    }

    private static int FindMaxIndex(List<int> list, int start, int end)
    {
        var maxIndex = start;
        var maxValue = list[start];

        for (int i = start + 1; i < end; i++)
        {
            if (list[i] > maxValue)
            {
                maxValue = list[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }


    public override ValueTask<string> Solve_1() => new($"Part 1: {ProcessPartOne()}");

    public override ValueTask<string> Solve_2() => new($"Part 2: {ProcessPartTwo()}");
}
