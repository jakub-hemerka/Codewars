using System.Text;

namespace CreatePhoneNumber;
public class Kata
{
    public static string CreatePhoneNumber(int[] numbers)
    {
        if (numbers.Length != 10)
        {
            return string.Empty;
        }

        StringBuilder builder = new StringBuilder();

        for (int i = 0; i < numbers.Length; i++)
        {
            switch (i)
            {
                case 0:
                    builder.Append('(');
                    break;
                case 3:
                    builder.Append(") ");
                    break;
                case 6:
                    builder.Append('-');
                    break;
                default:
                    break;
            }

            builder.Append(numbers[i]);
        }

        return builder.ToString();
    }
}