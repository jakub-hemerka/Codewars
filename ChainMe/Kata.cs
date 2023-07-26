namespace ChainMe;
public class Kata
{
    public static double Chain(double input, Func<double, double>[] fs)
    {
        foreach (Func<double, double> f in fs)
        {
            input = f.Invoke(input);
        }
        return input;
    }
}