namespace ProgramCalculatorPartOne;
public class Point
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    public Point(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Point GetOrigin()
    {
        return new Point(0, 0, 0);
    }

    public double GetDistanceFromOrigin()
    {
        return GetDistanceFromPoint(GetOrigin());
    }

    public double GetDistanceFromPoint(Point point)
    {
        return Math.Sqrt(Math.Pow(X - point.X, 2) + Math.Pow(Y - point.Y, 2) + Math.Pow(Z - point.Z, 2));
    }
}