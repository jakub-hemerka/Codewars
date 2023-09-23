using HistogramVTwo;

//string result = Dinglemouse.Histogram(new int[] { 0, 0, 0, 0, 0, 0 });
string result = Dinglemouse.Histogram(new int[] { 14, 6, 140, 30, 0, 10 });
//string result = Dinglemouse.Histogram(new int[] { 15, 15, 1, 21, 11, 17 });

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine(result);
Console.ResetColor();