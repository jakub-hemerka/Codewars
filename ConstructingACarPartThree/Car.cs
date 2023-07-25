namespace ConstructingACarPartThree;
public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;
    public IDrivingInformationDisplay drivingInformationDisplay; // car #2  
    public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

    private readonly IEngine _engine;
    private readonly IFuelTank _fuelTank;
    private readonly IDrivingProcessor _drivingProcessor; // car #2
    private readonly IOnBoardComputer _onBoardComputer; // car #3

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
        _onBoardComputer = new OnBoardComputer(_drivingProcessor, _fuelTank);

        fuelTankDisplay = new FuelTankDisplay(_fuelTank);
        drivingInformationDisplay = new DrivingInformationDisplay(_drivingProcessor);
        onBoardComputerDisplay = new OnBoardComputerDisplay(_onBoardComputer);
    }

    public bool EngineIsRunning => _engine.IsRunning;

    public void EngineStart()
    {
        if (!_engine.IsRunning && _fuelTank.FillLevel > 0)
        {
            _engine.Start();
            _drivingProcessor.EngineStart();
            _onBoardComputer.TripReset();
            _onBoardComputer.ElapseSecond();
        }
    }

    public void EngineStop()
    {
        if (_engine.IsRunning)
        {
            _engine.Stop();
            _drivingProcessor.EngineStop();
            _onBoardComputer.ElapseSecond();
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
            _onBoardComputer.ElapseSecond();
        }
    }

    public void Accelerate(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _drivingProcessor.IncreaseSpeedTo(speed);
        _onBoardComputer.ElapseSecond();
    }

    public void BrakeBy(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _drivingProcessor.ReduceSpeed(speed);
        _onBoardComputer.ElapseSecond();
    }

    public void FreeWheel()
    {
        if (_engine.IsRunning)
        {
            _drivingProcessor.ReduceSpeed(1);
            _onBoardComputer.ElapseSecond();
        }
    }
}