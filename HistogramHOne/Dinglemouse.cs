using System.Text;

namespace HistogramHOne;
public class Dinglemouse
{
    public static string Histogram(int[] results)
    {
        StringBuilder builder = new();

        for (int i = results.Length - 1; i >= 0; i--)
        {
            builder.Append($"{i + 1}|");
            if (results[i] > 0)
            {
                builder.Append($"{new string('#', results[i])} {results[i]}");
            }
            builder.AppendLine();
        }
        return builder.ToString();
    }
}