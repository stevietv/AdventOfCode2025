namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> _input;
    private int _position = 50;
    private int _zeroCount = 0;
    private int _timesPastZero = 0;
        


    public Day01()
    {
        _input = File.ReadAllLines(InputFilePath).ToList();
        ProcessInput();
    }

    private void ProcessInput()
    {
        foreach (var line in _input)
        {
            var direction = line[0];
            var turns = int.Parse(line[1..]);

            if (direction == 'R')
            {
                for (var i = 0; i < turns; i++)
                {
                    _position++;

                    if (_position == 100)
                    {
                        _position = 0;
                        _timesPastZero++;
                    }
                }
            }

            if (direction == 'L')
            {
                for (var i = 0; i < turns; i++)
                {
                    _position--;

                    if (_position == 0)
                    {
                        _timesPastZero++;
                    }

                    if (_position == -1)
                    {
                        _position = 99;
                    }
                }
            }

            if (_position == 0)
            {
                _zeroCount++;
            }
        }
    }

    public override ValueTask<string> Solve_1() => new($"{_zeroCount}");

    public override ValueTask<string> Solve_2() => new($"{_timesPastZero}");
}
