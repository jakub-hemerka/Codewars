namespace ProgramCalculatorPartTwo;
public class Vector
{
    public double I { get; private set; }
    public double J { get; private set; }
    public double K { get; private set; }

    public Vector(double i, double j, double k)
    {
        I = i;
        J = j;
        K = k;
    }

    public double GetMagnitude()
    {
        return Math.Sqrt(Math.Pow(I, 2) + Math.Pow(J, 2) + Math.Pow(K, 2));
    }

    public Vector Add(Vector vector)
    {
        return new Vector(I + vector.I, J + vector.J, K + vector.K);
    }

    public Vector MultiplyByScalar(double scalar)
    {
        return new Vector(I * scalar, J * scalar, K * scalar);
    }

    public double Dot(Vector vector)
    {
        return I * vector.I + J * vector.J + K * vector.K;
    }

    public Vector Cross(Vector vector)
    {
        double i = J * vector.K - K * vector.J;
        double j = (I * vector.K - K * vector.I) * -1;
        double k = I * vector.J - J * vector.I;
        return new Vector(i, j, k);
    }

    public bool IsParallelTo(Vector vector)
    {
        if (IsZeroVector(this) || IsZeroVector(vector))
        {
            return false;
        }

        return IsZeroVector(Cross(vector));
    }

    public bool IsPerpendicularTo(Vector vector)
    {
        if (IsZeroVector(this) || IsZeroVector(vector))
        {
            return false;
        }

        return Math.Round(Dot(vector)) == 0d;
    }

    public Vector Normalize()
    {
        return new Vector(I / GetMagnitude(), J / GetMagnitude(), K / GetMagnitude());
    }

    public bool IsNormalized()
    {
        return Math.Round(GetMagnitude()) == 1;
    }

    public static Vector GetI()
    {
        return new Vector(1, 0, 0);
    }

    public static Vector GetJ()
    {
        return new Vector(0, 1, 0);
    }

    public static Vector GetK()
    {
        return new Vector(0, 0, 1);
    }

    private static bool IsZeroVector(Vector vector)
    {
        return Math.Round(vector.I) == 0d && Math.Round(vector.J) == 0d && Math.Round(vector.K) == 0d;
    }
}