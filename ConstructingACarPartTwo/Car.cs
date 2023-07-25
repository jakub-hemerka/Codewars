namespace ConstructingACarPartTwo;
public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;
    public IDrivingInformationDisplay drivingInformationDisplay; // car #2  

    private readonly IEngine _engine;
    private readonly IFuelTank _fuelTank;
    private readonly IDrivingProcessor _drivingProcessor; // car #2

    public Car() : this(20)
    {
    }

    public Car(double fuelLevel) : this(fuelLevel, 10)
    {
    }

    public Car(double fuelLevel, int maxAcceleration) // car #2
    {
        _fuelTank = new FuelTank(fuelLevel);
        _engine = new Engine(_fuelTank);
        _drivingProcessor = new DrivingProcessor(_engine, maxAcceleration);
        
        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
        drivingInformationDisplay = new DrivingInformationDisplay(_drivingProcessor);
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
        if (_engine.IsRunning && _drivingProcessor.ActualSpeed == 0)
        {
            _drivingProcessor.ReduceSpeed(0);
        }
    }

    public void Accelerate(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _drivingProcessor.IncreaseSpeedTo(speed);
    }

    public void BrakeBy(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _drivingProcessor.ReduceSpeed(speed);
    }

    public void FreeWheel()
    {
        if (_engine.IsRunning)
        {
            _drivingProcessor.ReduceSpeed(1);
        }
    }
}