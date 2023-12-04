﻿using System.Text.RegularExpressions;
using Utils;

var lines = FileReader.ReadFile("input.txt");
char[] symbols = ['*', '#', '+', '$', '%', '/', '=', '-', '&','@'];
List<int> numbers = new();

for (int i = 0; i < lines.Length; i++)
{
  var matches = Regex.Matches(lines[i], @"[0-9]\d*");
  List<int> linesToCheck = GetLinesToCheck(i,lines.Length);
  foreach(var match in matches.Cast<Match>()) 
  {
    List<int> positionsToCheck = GetPositionsToCheck(match.Index, match.Length, lines[i].Length);

    foreach(int l in linesToCheck)
    {
      foreach(var p in positionsToCheck)
      {
        if (symbols.Contains(lines[l][p]))
        {
          numbers.Add(int.Parse(match.ValueSpan));
          continue;
        } 
      }              
    }
  }
}

static List<int> GetPositionsToCheck(int index, int length, int lineLength)
{
  var positions = new List<int>();
  if (index == 0) {
    for (int i=0; i <= length; i++)
      positions.Add(i);
  }
  else if (index + length == lineLength)
  {
    for (int i=index -1; i < lineLength; i++)
      positions.Add(i);

  } else {
    for (int i = index -1; i <= index + length; i++)
      positions.Add(i);
  }

  return positions;
}

static List<int> GetLinesToCheck(int i, int numberOfLines)
{
  var lineNumbers = new List<int>();

  lineNumbers.Add(i);
  if (i > 0)
    lineNumbers.Add(i -1);
  
  if (i < numberOfLines -1)
    lineNumbers.Add(i +1);

  return lineNumbers;
}

Console.WriteLine($"Answer part 1 : {numbers.Sum()}");

// part 2

int sumOfGearRatios = 0;

for(int l = 0; l < lines.Length; l++)
{  
  int[] starIndexes = Regex.Matches(lines[l], @"\*").Select(m => m.Index).ToArray();
  foreach(int s in starIndexes)
  {
    List<int> AdjecentNumbers = new();
  
    // left
    if(lines[l].Substring(s-1,1) != ".") 
    {
      var match = Regex.Match(lines[l].Substring(s-4, 4), @"[0-9]\d*");
      if (match.Success  && match.ValueSpan.Length > 1) AdjecentNumbers.Add(int.Parse(match.ValueSpan));
    }

    // right
    if (lines[l].Substring(s+1,1) != ".") {
      var match = Regex.Match(lines[l].Substring(s, 4), @"[0-9]\d*");
      if (match.Success  && match.ValueSpan.Length > 1) AdjecentNumbers.Add(int.Parse(match.ValueSpan));
    }

       
    if (l > 0 && lines[l-1].Substring(s-1,1) != "." && lines[l-1].Substring(s+1,1) != ".")
    {
      var matchesPrevLine = Regex.Matches(lines[l-1].Substring(s-3, 7), @"[0-9]\d*");
      foreach (var match in matchesPrevLine.Cast<Match>())
        if (match.Success && match.ValueSpan.Length > 1) AdjecentNumbers.Add(int.Parse(match.ValueSpan));
    }

    if(l < lines.Length-1 && lines[l+1].Substring(s-1,1) != "." && lines[l+1].Substring(s+1,1) != ".")
    {
      var matchesNextLine = Regex.Matches(lines[l+1].Substring(s-3, 7), @"[0-9]\d*");
      foreach (var match in matchesNextLine.Cast<Match>())
        if (match.Success && match.ValueSpan.Length > 1) AdjecentNumbers.Add(int.Parse(match.ValueSpan));
    }

    if (AdjecentNumbers.Count == 2)
      sumOfGearRatios += AdjecentNumbers[0] * AdjecentNumbers[1];
  }
}

Console.WriteLine($"Answer part 2: {sumOfGearRatios}");