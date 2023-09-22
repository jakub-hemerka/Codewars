namespace Noobify;
public static class Kata
{
    private static readonly Dictionary<string, string> _replacements = new Dictionary<string, string>()
    {
        { ".", string.Empty },
        { ",", string.Empty },
        { "'", string.Empty },
        { "too", "2" },
        { "to", "2" },
        { "fore", "4" },
        { "for", "4" },
        { "be", "b" },
        { "are", "r" },
        { "you", "u" },
        { "please", "plz" },
        { "people", "ppl" },
        { "really", "rly" },
        { "have", "haz" },
        { "know", "no" },
        { "s", "z" },
        { "oo", "00" }
    };

    public static string N00bify(string input)
    {
        List<string> words = input.Split(' ').ToList();

        words = words.ModifyWords().InsertLOL().InsertOMG().Capitalize().ModifyQuestionMarks().ModifyExlamationPoints();

        return string.Join(' ', words);
    }

    private static List<string> ModifyExlamationPoints(this List<string> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = words[i].Replace("!", string.Join("", Enumerable.Range(0, words.Count).Select(x => x % 2 == 0 ? "!" : "1")));
        }

        return words;
    }

    private static List<string> ModifyQuestionMarks(this List<string> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = words[i].Replace("?", new string('?', words.Count));
        }

        return words;
    }

    private static List<string> InsertLOL(this List<string> words)
    {
        if (words[0].StartsWith("W", StringComparison.InvariantCultureIgnoreCase))
        {
            words.Insert(0, "LOL");
        }

        return words;
    }

    private static List<string> InsertOMG(this List<string> words)
    {
        if (words.Sum(w => w.Count(x => char.IsLetterOrDigit(x))) + (words.Count - 1) >= 32)
        {
            int position = words[0] == "LOL" ? 1 : 0;
            words.Insert(position, "OMG");
        }

        return words;
    }

    private static List<string> Capitalize(this List<string> words)
    {
        int start = 1;
        int step = 2;

        if (words.First().StartsWith("H", StringComparison.InvariantCultureIgnoreCase))
        {
            start = 0;
            step = 1;
        }

        for (int i = start; i < words.Count; i += step)
        {
            words[i] = words[i].ToUpper();
        }

        return words;
    }

    private static List<string> ModifyWords(this List<string> words)
    {
        for (int i = 0; i < words.Count; i++)
        {
            words[i] = ModifyWord(words[i]);
        }

        return words;
    }

    private static string ModifyWord(string word)
    {
        foreach (KeyValuePair<string, string> replacement in _replacements)
        {
            if (!word.Contains(replacement.Key, StringComparison.InvariantCultureIgnoreCase))
            {
                continue;
            }

            if (replacement.Value.Length == 0)
            {
                word = word.Replace(replacement.Key, replacement.Value);
                continue;
            }
            
            word = word.SwapLetters(replacement.Key, replacement.Value);
        }

        return word;
    }

    private static string SwapLetters(this string word, string pattern, string replacement)
    {
        while (true)
        {
            int index = word.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase);

            if (index == -1)
            {
                break;
            }

            string cut = word.Substring(index, pattern.Length);
            string repl = $"{replacement[0]}";

            if (char.IsLetter(repl[0]) && char.IsUpper(cut[0]))
            {
                repl = repl.ToUpper();
            }

            if (pattern.Length > 1)
            {
                repl += replacement[1..];
            }

            word = word.Replace(cut, repl);
        }

        return word;
    }
}