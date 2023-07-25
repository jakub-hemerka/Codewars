namespace ConstructingACarPartOne;
public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;

    private readonly IEngine _engine;
    private readonly IFuelTank _fuelTank;

    public Car() : this(20)
    {
    }

    public Car(double fuelLevel)
    {
        _fuelTank = new FuelTank(fuelLevel);
        _engine = new Engine(_fuelTank);
        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
    }

    public bool EngineIsRunning => _engine.IsRunning;

    public void EngineStart()
    {
        if (!_engine.IsRunning && _fuelTank.FillLevel > 0)
        {
            _engine.Start();
        }
    }

    public void EngineStop()
    {
        if (_engine.IsRunning)
        {
            _engine.Stop();
        }
    }

    public void Refuel(double liters)
    {
        _fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
        if (_engine.IsRunning)
        {
            _engine.Consume(0.0003);
        }
    }
}