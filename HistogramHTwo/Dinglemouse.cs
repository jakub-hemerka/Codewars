using System.Text;

namespace HistogramHOne;
public class Dinglemouse
{
    public static string Histogram(int[] results)
    {
        StringBuilder builder = new();
        int totalRolls = results.Sum();
        int maximumBars = 50;
        char bar = '\u2588';

        for (int i = results.Length - 1; i >= 0; i--)
        {
            builder.Append($"{i + 1}|");
            if (results[i] > 0)
            {
                int percentage = (int)Math.Floor((100f * results[i]) / totalRolls);
                int numberOfBars = (int)Math.Floor((maximumBars * percentage) / 100f);
                builder.Append($"{new string(bar, numberOfBars)} {percentage}%");
            }
            builder.AppendLine();
        }
        return builder.ToString();
    }
}