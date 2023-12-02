using Day2;
using Utils;

var lines = FileReader.ReadFile("input.txt");
var games = new List<Game>();
int sum = 0;

foreach(var line in lines) 
  games.Add(ParseLineToGame(line));

var validGames = games.Where(g => g.IsValid());
sum = validGames.Sum(g => g.Id);

Console.WriteLine($"Answer part 1: {sum}");


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


