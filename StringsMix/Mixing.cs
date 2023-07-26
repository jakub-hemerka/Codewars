namespace StringsMix;
public class Mixing
{
    public static string Mix(string s1, string s2)
    {
        List<LetterOccurrence> occurrences = new List<LetterOccurrence>();

        for (int i = 'a'; i <= 'z'; i++)
        {
            int first = s1.Count(c => c == (char)i);
            int second = s2.Count(c => c == (char)i);

            if (first > 1 || second > 1)
            {
                occurrences.Add(new LetterOccurrence((char)i, first, second));
            }
        }

        return string.Join('/', occurrences.OrderByDescending(x => x.Body.Length).ThenBy(x => x.Prefix));
    }
}

public class LetterOccurrence
{
    public char Prefix { get; private set; }
    public string Body { get; private set; }

    public LetterOccurrence(char letter, int first, int second)
    {
        Body = string.Join(null, Enumerable.Repeat(letter, Math.Max(first, second)));

        if (first == second)
        {
            Prefix = '=';
        }

        if (first > second)
        {
            Prefix = '1';
        }

        if (first < second)
        {
            Prefix = '2';
        }
    }

    public override string ToString()
    {
        return $"{Prefix}:{Body}";
    }
}