namespace DigitalRoot;
public class Number
{
    public int DigitalRoot(long n)
    {
        while (n >= 10)
        {
            n = CountDigits(n);
        }

        return (int)n;
    }

    private static long CountDigits(long number)
    {
        long sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }
}