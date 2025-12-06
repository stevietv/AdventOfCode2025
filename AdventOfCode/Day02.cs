namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private string[] _ranges;
    private readonly List<long> _invalidIdsPartOne = [];
    private readonly List<long> _invalidIdsPartTwo = [];

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        ProcessInput();
    }

    private void ProcessInput()
    {
        _ranges = _input.Split(',');

        foreach (var range in _ranges)
        {
            var split = range.Split('-');
            var start = long.Parse(split[0]);
            var end = long.Parse(split[1]);

            while (start <= end)
            {
                if (CheckSimpleRepetition(start))
                {
                    _invalidIdsPartOne.Add(start);
                }

                if (CheckComplexRepetition(start))
                {
                    _invalidIdsPartTwo.Add(start);
                }
                
                start++;
            }
        }        
    }

    private static bool CheckSimpleRepetition(long value)
    {
        var inputString = value.ToString();
        var firstHalf = inputString.Substring(0, inputString.Length / 2);
        var secondHalf = inputString.Substring(inputString.Length / 2);
   
        return firstHalf.Equals(secondHalf);
    }

    private static bool CheckComplexRepetition(long value)
    {
        var inputString = value.ToString();

        for (var i = 1; i < (inputString.Length) ; i++)
        {
            
            // Split the string into equal chunk lengths which produces a number of char[] arrays. Convert these to a string and store in a list.
            // if there is only one distinct item in the resulting list then the chunks repeated throughout the pattern
            var substrings = inputString.Chunk(i).Select(chunk => string.Concat(chunk)).ToList();
            if (substrings.Select(substring => substring).Distinct().Count() == 1)
                return true;
        }
        
        return false;
    }

    public override ValueTask<string> Solve_1() => new($"Part 1: {_invalidIdsPartOne.Sum()}");

    public override ValueTask<string> Solve_2() => new($"Part 2: {_invalidIdsPartTwo.Sum()}");
}
