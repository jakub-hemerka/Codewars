using System.Text;

namespace HistogramVTwo;
public class Dinglemouse
{
    public static string Histogram(int[] results)
    {
        StringBuilder builder = new();
        string[,] table = BuildTable(results);

        for (int i = table.GetLength(1) - 1; i >= 0; i--)
        {
            string line = "";
            for (int j = 0; j < table.GetLength(0); j++)
            {
                line += table[j, i];
            }

            if (line.Trim().Length > 0)
            {
                builder.AppendLine(line.TrimEnd());
            }
        }
        return builder.ToString();
    }

    private static string[,] BuildTable(int[] values)
    {
        int maximumBars = 15;
        int totalRolls = values.Sum();
        char bar = '\u2588';
        string[,] output = new string[values.Length, maximumBars + 3];

        for (int i = 0; i < output.GetLength(0); i++)
        {
            output[i, 0] = $" {i + 1} ";
            output[i, 1] = "---";
            int percentage = (int)Math.Floor((100f * values[i]) / totalRolls);
            int numberOfBars = (int)Math.Floor((maximumBars * values[i]) / (float)totalRolls);

            for (int j = 2; j < output.GetLength(1); j++)
            {
                output[i, j] = j <= numberOfBars + 1 ? $"{bar}{bar} " : "   ";
            }

            if (values[i] > 0)
            {
                output[i, numberOfBars + 2] = percentage < 1f ? $"<1%".PadRight(3, ' ') : $"{percentage}%".PadRight(3, ' ');
            }
        }

        return output;
    }
}