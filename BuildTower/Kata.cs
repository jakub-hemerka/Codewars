namespace BuildTower;
public class Kata
{
    public static string[] Build(int nFloors)
    {
        string[] output = new string[nFloors];
        int dotCount = 1;
        int maxWidth = nFloors > 1 ? 1 + (2 * (nFloors - 1)) : 1;

        for (int i = 0; i < nFloors; i++)
        {
            int spaceWidth = (maxWidth - dotCount) / 2;
            output[i] = string.Format("{0}{1}{0}", new string(' ', spaceWidth), new string('*', dotCount));
            dotCount += 2;
        }

        return output;
    }
}