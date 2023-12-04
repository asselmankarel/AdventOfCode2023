namespace Day4;

public class Card 
{
  public int Id { get; set; }
  public int[] WinningNumbers { get; set; } = new int[10];
  public int[] CardNumbers { get; set; } = new int[25];
  public int Matches { get; private set; }

  public int CalculateScore()
  {
    Matches = 0;
    foreach(int n in WinningNumbers)
      if (CardNumbers.Contains(n)) Matches++;

    if (Matches == 0) return 0;

    return (int)Math.Pow(2, Matches -1);
  }
}