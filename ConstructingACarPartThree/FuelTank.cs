namespace ConstructingACarPartThree;
public class FuelTank : IFuelTank
{
    private double _fillLevel;
    private readonly double _tankSize;

    public double FillLevel => _fillLevel;
    public bool IsOnReserve => _fillLevel < 5d;
    public bool IsComplete => _fillLevel == _tankSize;

    public FuelTank() : this(20)
    {
    }

    public FuelTank(double liters)
    {
        _tankSize = 60d;
        if (liters < 0)
        {
            _fillLevel = 0;
            return;
        }

        if (liters > _tankSize)
        {
            _fillLevel = _tankSize;
            return;
        }

        _fillLevel = liters;
    }

    public void Consume(double liters)
    {
        _fillLevel -= liters;
        _fillLevel = Math.Round(_fillLevel, 10, MidpointRounding.AwayFromZero);
        if (_fillLevel < 0)
        {
            _fillLevel = 0;
        }
    }

    public void Refuel(double liters)
    {
        if (liters < 0)
        {
            return;
        }
        
        _fillLevel += liters;

        if (_fillLevel > _tankSize)
        {
            _fillLevel = _tankSize;
        }
    }
}