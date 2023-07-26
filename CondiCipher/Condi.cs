namespace CondiCipher;
public class Condi
{
    public static string Encode(string message, string key, int initShift)
    {
        List<char> alphabet = new(25);
        FilterKey(key, alphabet);
        CompleteAlphabet(alphabet);

        string output = ChangeMessage(message, alphabet, initShift, false);

        return output;
    }

    public static string Decode(string message, string key, int initShift)
    {
        List<char> alphabet = new(25);
        FilterKey(key, alphabet);
        CompleteAlphabet(alphabet);

        string output = ChangeMessage(message, alphabet, initShift, true);

        return output;
    }

    private static string ChangeMessage(string message, List<char> alphabet, int shift, bool moveLeft)
    {
        char[] output = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            if (!alphabet.Contains(message[i]))
            {
                output[i] = message[i];
                continue;
            }

            if (moveLeft && shift > 0)
            {
                shift = NegateShift(shift);
            }

            int currentindex = alphabet.IndexOf(message[i]);
            int newindex = currentindex + shift;

            if (moveLeft)
            {
                while (newindex < 0)
                {
                    newindex += 26;
                }
                shift = newindex + 1;
            }
            else
            {
                if (newindex >= alphabet.Count)
                {
                    newindex %= 26;
                }
                shift = currentindex + 1;
            }

            output[i] = alphabet[newindex];
        }

        return new string(output);
    }

    private static int NegateShift(int shift)
    {
        return shift * -1;
    }

    private static void CompleteAlphabet(List<char> alphabet)
    {
        for (int i = 'a'; i <= 'z'; i++)
        {
            if (!alphabet.Contains((char)i))
            {
                alphabet.Add((char)i);
            }
        }
    }

    private static void FilterKey(string key, List<char> aphlabet)
    {
        foreach (char c in key)
        {
            if (!aphlabet.Contains(c))
            {
                aphlabet.Add(c);
            }
        }
    }
}