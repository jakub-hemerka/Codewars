using System.Text;

namespace HistogramVOne;
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
        string[,] output = new string[values.Length, values.Max() + 3];

        for (int i = 0; i < output.GetLength(0); i++)
        {
            output[i, 0] = $"{i + 1} ";
            output[i, 1] = i + 1 < output.GetLength(0) ? "--" : "-";

            for (int j = 2; j < output.GetLength(1); j++)
            {
                output[i, j] = j <= values[i] + 1 ? "# " : "  ";
            }

            if (values[i] > 0)
            {
                output[i, values[i] + 2] = $"{values[i]}".PadRight(2, ' ');
            }
        }

        return output;
    }
}