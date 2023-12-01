
using System.Text.RegularExpressions;
using Utils;

var lines = FileReader.ReadFile("input.txt");
int sum = 0;

foreach (var line in lines)
{
    var result = Regex.Matches(line, @"[0-9]");
    int number = int.Parse(result[0].ToString() + result[^1].ToString());
    sum += number;
}

Console.WriteLine($"Answer: {sum}");
