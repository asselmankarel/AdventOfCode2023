using Day2;
using Utils;

var lines = FileReader.ReadFile("input.txt");
var games = new List<Game>();
int sum = 0;
int sumOfPowers = 0;

foreach(var line in lines) 
  games.Add(ParseLineToGame(line));

sum = games.Where(g => g.IsValid()).Sum(g => g.Id);
Console.WriteLine($"Answer part 1: {sum}");


// Part 2
foreach(var game in games) 
{
  int maxBlue = game.Sets.Select(s => s).Max( s => s.Blue);
  int maxGreen = game.Sets.Select(s => s).Max( s => s.Green);
  int maxRed = game.Sets.Select(s => s).Max( s => s.Red);

  int power = maxBlue * maxGreen * maxRed;
  sumOfPowers += power;
}

Console.WriteLine($"Answer part 2: {sumOfPowers}");


Game ParseLineToGame(string line) 
{
  var game = new Game();
  int startIndex = line.IndexOf(' ') + 1;
  int endIndex = line.IndexOf(':');
  game.Id = int.Parse(line[startIndex..endIndex]);
  string[] setsStr = line.Substring(endIndex + 1, line.Length - endIndex -1).Split(';');
  ParseSets(setsStr, game);

  return game;
}

void ParseSets(string[] setsStr, Game game) 
{
  foreach(string setStr in setsStr)
  {
    var matches = setStr.Split(';');
    foreach(string match in matches) 
    {
      var set = new Set();
      var entries = match.Split(',');

      foreach(string entry in entries)
      {
        var result = entry.Trim().Split(' ');
        string cubes = result[0];
        string color = result[1];

        switch (color)
        {
          case "blue" : set.Blue  = int.Parse(cubes); break;
          case "green": set.Green = int.Parse(cubes); break;
          case "red"  : set.Red   = int.Parse(cubes); break;
          default: break;
        }
      }

      game.Sets.Add(set);
    }
  }
}


