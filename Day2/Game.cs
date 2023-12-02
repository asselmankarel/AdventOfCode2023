namespace Day2;

public class Game
{
  public int Id { get; set; } 
  public List<Set> Sets { get; set; } = new();

  public bool IsValid() 
  {
    return !Sets.Exists(s => s.Blue > 14 || s.Green > 13 || s.Red > 12);
  }

}