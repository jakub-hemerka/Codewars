namespace TextAlignJustify;
public class Kata
{
    public static string Justify(string str, int len)
    {
        if (str.Length == 0)
        {
            return "";
        }

        string[] words = str.Split(' ');

        if (words.Length < 2)
        {
            return str;
        }

        List<string> lines = new List<string>();
        List<string> line = new List<string>();
        int charCount = 0;

        foreach (string word in words)
        {
            if (charCount + word.Length + line.Count - 1 >= len)
            {
                lines.Add(FormatLine(line, len - charCount));
                line.Clear();
                charCount = 0;
            }

            charCount += word.Length;
            line.Add(word);

            if (word == words[^1])
            {
                lines.Add(string.Join(' ', line));
            }
        }

        return string.Join('\n',lines);
    }

    private static string FormatLine(List<string> line, int difference)
    {
        int spacesPerSlot = (int)Math.Floor(difference / (line.Count - 1d));
        int excess = difference - (spacesPerSlot * (line.Count - 1));
        for (int i = 0; i < line.Count - 1; i++)
        {
            line[i] = $"{line[i]}{new string(' ', excess > 0 ? spacesPerSlot + 1 : spacesPerSlot)}";
            excess -= 1;

            if (difference <= 0)
            {
                break;
            }
        }

        return string.Join("", line);
    }
}