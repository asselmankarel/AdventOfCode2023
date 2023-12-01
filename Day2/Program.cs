using Utils;

var lines = FileReader.ReadFile("input.txt");


Dictionary<char, int> map = new Dictionary<char, int>()
{
    { 'X',  1},
    { 'Y',  2},
    { 'Z',  3},
};

int total = 0;

foreach (var line in lines)
{
    total += line.Split(' ') switch
    {
        ["A", "Y"] => 6, // win
        ["B", "Z"] => 6,
        ["C", "X"] => 6,
        ["A", "X"] => 3, // draw
        ["B", "Y"] => 3,
        ["C", "Z"] => 3,
        _ => 0 // loss
    };

    char myMove = line[2];
    total += map.GetValueOrDefault(myMove);
}

Console.WriteLine($"Total score: {total}");

// Part Two
total = 0;

foreach (var line in lines)
{
    char opponentsMove = line[0];

    int score = line.Split(' ') switch
    {
        [_, "Y"] => 3, // draw
        [_, "Z"] => 6,
        _ => 0,
    };

    char me = GetCounterMove(opponentsMove, score);

    total += score;
    total += map.GetValueOrDefault(me);
}

Console.WriteLine($"Total score part two: {total}");

static char GetCounterMove(char opponentsMove, int score)
{
    if (score == 6)
    {
        return opponentsMove switch
        {
            'A' => 'Y',
            'B' => 'Z',
            'C' => 'X',
        };
    }
    if (score == 3)
    {
        return opponentsMove switch
        {
            'A' => 'X',
            'B' => 'Y',
            'C' => 'Z',
        };
    }

    return opponentsMove switch
    {
        'A' => 'Z',
        'B' => 'X',
        'C' => 'Y',
    };
}
