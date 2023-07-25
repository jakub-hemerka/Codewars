namespace ConstructingACarPartTwo;
public class DrivingProcessor : IDrivingProcessor // car #2
{
    private readonly IEngine _engine;
    private int _actualSpeed;
    private double _actualConsumption;
    private readonly int _maximumSpeed;
    private readonly int _acceleration;
    private readonly int _maximumBraking;
    public int ActualSpeed => _actualSpeed;

    public DrivingProcessor(IEngine engine) : this(engine, 10)
    {
    }

    public DrivingProcessor(IEngine engine, int acceleration)
    {
        _engine = engine;
        if (acceleration > 20)
        {
            acceleration = 20;
        }

        if (acceleration < 5)
        {
            acceleration = 5;
        }

        _actualSpeed = 0;
        _maximumSpeed = 250;
        _maximumBraking = 10;
        _acceleration = acceleration;
    }

    public void IncreaseSpeedTo(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        if (speed < 0 || speed < _actualSpeed)
        {
            _actualSpeed -= 1;
        }

        if (_actualSpeed < speed)
        {
            _actualSpeed = Math.Min(speed, _actualSpeed + _acceleration);
        }

        if (_actualSpeed > _maximumSpeed)
        {
            _actualSpeed = _maximumSpeed;
        }

        Consume();
    }

    public void ReduceSpeed(int speed)
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _actualSpeed -= Math.Min(speed, _maximumBraking);

        if (_actualSpeed < 0)
        {
            _actualSpeed = 0;
        }

        if (_actualSpeed == 0)
        {
            // Running Idle...
            Consume();
        }
    }

    private void Consume()
    {
        if (!_engine.IsRunning)
        {
            return;
        }

        _actualConsumption = _actualSpeed switch
        {
            > 200 and <= 250 => 0.0030,
            > 140 and <= 200 => 0.0025,
            > 100 and <= 140 => 0.0020,
            > 60 and <= 100 => 0.0014,
            > 0 and <= 60 => 0.0020,
            _ => 0.0003,
        };

        _engine.Consume(_actualConsumption);
    }
}