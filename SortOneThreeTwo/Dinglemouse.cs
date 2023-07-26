using System.Text;

namespace SortOneThreeTwo;
public class Dinglemouse
{
    public static int[] Sort(int[] array)
    {
        if (array.Length == 0)
        {
            return Array.Empty<int>();
        }

        string[] uniques = { "blank", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        string[] tens = { "blank", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        (int, string)[] values = new (int, string)[array.Length];
        StringBuilder builder = new();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == 0)
            {
                values[i] = (array[i], "zero");
                continue;
            }
            values[i] = (array[i], ConvertToWord(array[i], uniques, tens, builder));
        }

        return values.OrderBy(x => x.Item2).Select(x => x.Item1).ToArray();
    }

    private static string ConvertToWord(int number, string[] uniques, string[] tens, StringBuilder builder)
    {
        builder.Clear();
        if (number >= 100)
        {
            builder.Append($"{uniques[number / 100]} hundred");
            number %= 100;
        }

        if (number == 0)
        {
            return builder.ToString();
        }

        if (builder.Length > 0)
        {
            builder.Append(" and ");
        }

        if (number > 19)
        {
            builder.Append($"{tens[number / 10]}");
            number %= 10;

            if (number > 0)
            {
                builder.Append($"-{uniques[number]}");
            }

            return builder.ToString();
        }

        builder.Append($"{uniques[number]}");

        return builder.ToString();
    }
}