using Utils;

var lines = FileReader.ReadFile("input.txt");

int max = 0;
int sum = 0;
List<int> totalByElf = new();

foreach (var line in lines)
{
    if (line == string.Empty)
    {
        if (sum > max)
            max = sum;

        totalByElf.Add(sum);
        sum = 0;
    } 

    if (int.TryParse(line, out int value))
        sum += value; 
}

int topThree = totalByElf.OrderByDescending(x => x).Take(3).Sum();

Console.WriteLine($"The answer is: {max}");
Console.WriteLine($"Top 3 total is: {topThree}");