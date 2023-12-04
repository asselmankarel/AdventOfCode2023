using Utils;
using Day4;
using System.Text.RegularExpressions;

var lines = FileReader.ReadFile("input.txt");
int total =0;

foreach(string line in lines)
{
  var card = new Card();
  string[] part = line.Split(':');
  card.Id = int.Parse(part[0].Split(' ').Last());
  string[] numbers = part.Last().Split('|');
  card.WinningNumbers = Regex.Matches(numbers.First(), @"[0-9]\d*").Select(m => int.Parse(m.ValueSpan)).ToArray();
  card.CardNumbers = Regex.Matches(numbers.Last(), @"[0-9]\d*").Select(m => int.Parse(m.ValueSpan)).ToArray();
  total += card.CalculateScore();
}

Console.WriteLine($"Answer part 1: {total}");