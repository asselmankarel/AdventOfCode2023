using Utils;
using Day4;
using System.Text.RegularExpressions;

var lines = FileReader.ReadFile("input.txt");
int totalPart1 =0;
int totalPart2 = 0;
List<Card> cards = new();
Queue<Card> queue = new();

foreach(string line in lines)
{
  var card = new Card();
  string[] part = line.Split(':');
  card.Id = int.Parse(part[0].Split(' ').Last());
  string[] numbers = part.Last().Split('|');
  card.WinningNumbers = Regex.Matches(numbers.First(), @"[0-9]\d*").Select(m => int.Parse(m.ValueSpan)).ToArray();
  card.CardNumbers = Regex.Matches(numbers.Last(), @"[0-9]\d*").Select(m => int.Parse(m.ValueSpan)).ToArray();
  totalPart1 += card.CalculateScore();
  cards.Add(card);
  queue.Enqueue(card);
}

Console.WriteLine($"Answer part 1: {totalPart1}");

totalPart2 = cards.Count;

while(queue.Count > 0 )
{
  var card = queue.Dequeue();
  for(int i = 1; i <= card.Matches; i++)
  {
    Card cardToAdd = cards.Find(c => c.Id == card.Id + i);
    queue.Enqueue(cardToAdd);
    totalPart2++;
  }
}

Console.WriteLine($"Answer part 2: {totalPart2}");
