namespace BuildingSpheres;
public class Sphere
{
    private readonly int _radius;
    private readonly int _mass;
    private readonly double _volume;
    private readonly double _surfaceArea;
    private readonly double _density;

    public Sphere(int radius, int mass)
    {
        _radius = radius;
        _mass = mass;
        _volume = (4 / 3d) * Math.PI * Math.Pow(_radius, 3);
        _surfaceArea = 4 * Math.PI * Math.Pow(_radius, 2);
        _density = _mass / _volume;
    }

    public int GetRadius() => _radius;
    public int GetMass() => _mass;
    public double GetVolume() => _volume;
    public double GetSurfaceArea() => _surfaceArea;
    public double GetDensity() => _density;
}