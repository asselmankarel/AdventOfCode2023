namespace Day4;

public class Card 
{
  public int Id { get; set; }
  public int[] WinningNumbers { get; set; } = new int[5];
  public int[] CardNumbers { get; set; } = new int[8];

  public int CalculateScore()
  {
    int matches = -1;
    foreach(int n in WinningNumbers)
      if (CardNumbers.Contains(n)) matches++;

    if (matches == -1) return 0;

    return (int)Math.Pow(2, matches);
  }
}