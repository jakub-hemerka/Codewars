namespace ConstructingACarPartOne;
public class Engine : IEngine
{
    private bool _isRunning;
    private readonly IFuelTank _fuelTank;

    public bool IsRunning => _isRunning;

    public Engine(IFuelTank fuelTank)
    {
        _fuelTank = fuelTank;
        _isRunning = false;
    }

    public void Consume(double liters)
    {
        if (_isRunning)
        {
            _fuelTank.Consume(liters);
        }

        if (_fuelTank.FillLevel <= 0)
        {
            Stop();
        }
    }

    public void Start()
    {
        if (_fuelTank.FillLevel > 0)
        {
            _isRunning = true;
        }
    }

    public void Stop()
    {
        _isRunning = false;
    }
}