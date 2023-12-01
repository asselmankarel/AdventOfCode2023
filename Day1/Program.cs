using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using Utils;

var lines = FileReader.ReadFile("input.txt");
int sum = 0;

foreach (var line in lines)
{
    var result = Regex.Matches(line, @"[1-9]");
    sum += int.Parse(result[0].ToString() + result[^1].ToString());
}

Console.WriteLine($"Answer part 1: {sum}");

// part 2

sum = 0;

foreach(var line in lines)
{
  List<char> chars = new();
  
  for(int i=0; i < line.Length; i++)
  {
    string subString = line[i..];
    if (subString.StartsWith("one")) chars.Add('1');
    else if (subString.StartsWith("two")) chars.Add('2');
    else if (subString.StartsWith("three")) chars.Add('3');
    else if (subString.StartsWith("four")) chars.Add('4');
    else if (subString.StartsWith("five")) chars.Add('5');
    else if (subString.StartsWith("six")) chars.Add('6');
    else if (subString.StartsWith("seven")) chars.Add('7');
    else if (subString.StartsWith("eight")) chars.Add('8');
    else if (subString.StartsWith("nine")) chars.Add('9');
    else if (subString.StartsWith("1")) chars.Add('1');
    else if (subString.StartsWith("2")) chars.Add('2');
    else if (subString.StartsWith("3")) chars.Add('3');
    else if (subString.StartsWith("4")) chars.Add('4');
    else if (subString.StartsWith("5")) chars.Add('5');
    else if (subString.StartsWith("6")) chars.Add('6');
    else if (subString.StartsWith("7")) chars.Add('7');
    else if (subString.StartsWith("8")) chars.Add('8');
    else if (subString.StartsWith("9")) chars.Add('9');
  }
  sum += int.Parse($"{chars[0]}{chars[^1]}");
}

Console.WriteLine($"Answer part 2: {sum}");