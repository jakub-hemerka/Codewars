namespace ConstructingACarPartThree;
public class OnBoardComputer : IOnBoardComputer // car #3
{
    private int _tripRealTime;
    private int _tripDrivingTime;
    private int _tripDrivenDistance;
    private int _totalRealTime;
    private int _totalDrivingTime;
    private int _totalDrivenDistance;
    private int _tripSpeed;
    private int _totalSpeed;
    private double _tripAverageSpeed;
    private double _totalAverageSpeed;
    private double _actualConsumptionByTime;
    private double _actualConsumptionByDistance;
    private double _tripAverageConsumptionByTime;
    private double _totalAverageConsumptionByTime;
    private double _tripConsumptionByDistance;
    private double _totalConsumptionByDistance;
    private double _tripAverageConsumptionByDistance;
    private double _totalAverageConsumptionByDistance;
    private double _tripConsumption;
    private double _totalConsumption;
    private int _estimatedRange;
    private readonly IDrivingProcessor _drivingProcessor;
    private readonly IFuelTank _fuelTank;
    private readonly Queue<double> _recentConsumption;

    public int TripRealTime => _tripRealTime;
    public int TripDrivingTime => _tripDrivingTime;
    public int TripDrivenDistance => _tripDrivenDistance;
    public int TotalRealTime => _totalRealTime;
    public int TotalDrivingTime => _totalDrivingTime;
    public int TotalDrivenDistance => _totalDrivenDistance;
    public double TripAverageSpeed => _tripAverageSpeed;
    public double TotalAverageSpeed => _totalAverageSpeed;
    public int ActualSpeed => _drivingProcessor.ActualSpeed;
    public double ActualConsumptionByTime => _actualConsumptionByTime;
    public double ActualConsumptionByDistance => _drivingProcessor.ActualSpeed > 0 ? _actualConsumptionByDistance : double.NaN;
    public double TripAverageConsumptionByTime => _tripAverageConsumptionByTime;
    public double TotalAverageConsumptionByTime => _totalAverageConsumptionByTime;
    public double TripAverageConsumptionByDistance => _tripAverageConsumptionByDistance;
    public double TotalAverageConsumptionByDistance => _totalAverageConsumptionByDistance;
    public int EstimatedRange => _estimatedRange;

    public OnBoardComputer(IDrivingProcessor drivingProcessor, IFuelTank fuelTank)
    {
        _drivingProcessor = drivingProcessor;
        _fuelTank = fuelTank;
        _recentConsumption = new();
        FactoryConsumption();
    }

    public void ElapseSecond()
    {
        if (_drivingProcessor.ActualConsumption > 0)
        {
            AddConsumption(_drivingProcessor.ActualConsumption * 3600 * (100d / _drivingProcessor.ActualSpeed));
        }
        _tripRealTime += 1;
        _totalRealTime += 1;
        _actualConsumptionByTime = _drivingProcessor.ActualConsumption;
        _tripConsumption += _drivingProcessor.ActualConsumption;
        _totalConsumption += _drivingProcessor.ActualConsumption;
        _tripAverageConsumptionByTime = _tripConsumption / _tripRealTime;
        _totalAverageConsumptionByTime = _totalConsumption / _totalRealTime;

        if (_drivingProcessor.ActualSpeed > 0)
        {
            _tripDrivingTime += 1;
            _totalDrivingTime += 1;
            _tripDrivenDistance += _drivingProcessor.ActualSpeed;
            _totalDrivenDistance += _drivingProcessor.ActualSpeed;
            CalculateAverageSpeed();
            CalculateActualConsumptionByDistance();
            CalculateAverageConsumptionByDistance();
        }
        CalculateEstimatedRange();
    }

    private void CalculateAverageSpeed()
    {
        _tripSpeed += _drivingProcessor.ActualSpeed;

        if (_tripDrivingTime > 0)
        {
            _tripAverageSpeed = _tripSpeed / (double)_tripDrivingTime;
        }

        _totalSpeed += _drivingProcessor.ActualSpeed;

        if (_totalDrivingTime > 0)
        {
            _totalAverageSpeed = _totalSpeed / (double)_totalDrivingTime;
        }
    }

    private void CalculateActualConsumptionByDistance()
    {
        _actualConsumptionByDistance = Math.Round(_drivingProcessor.ActualConsumption * 3600 * (100d / _drivingProcessor.ActualSpeed), 5, MidpointRounding.AwayFromZero);
    }

    private void CalculateAverageConsumptionByDistance()
    {
        _tripConsumptionByDistance += _actualConsumptionByDistance;
        
        if (_tripDrivingTime > 0)
        {
            _tripAverageConsumptionByDistance = _tripConsumptionByDistance / _tripDrivingTime;
        }

        _totalConsumptionByDistance += _actualConsumptionByDistance;

        if (_totalDrivingTime > 0)
        {
            _totalAverageConsumptionByDistance = _totalConsumptionByDistance / _totalDrivingTime;
        }
    }

    private void CalculateEstimatedRange()
    {
        double fuelConsumption = _recentConsumption.Sum() / 100;
        double fuelEconomy = 1 / fuelConsumption * 100;
        _estimatedRange = (int)Math.Round(_fuelTank.FillLevel * fuelEconomy);
    }

    public void TotalReset()
    {
        _totalRealTime = 0;
        _totalDrivingTime = 0;
        _totalDrivenDistance = 0;
        _totalAverageSpeed = 0;
        _totalAverageConsumptionByTime = 0;
        _totalAverageConsumptionByDistance = 0;
        _totalConsumption = 0;
        _totalConsumptionByDistance = 0;
        _totalSpeed = 0;
    }

    public void TripReset()
    {
        _tripRealTime = 0;
        _tripDrivingTime = 0;
        _tripDrivenDistance = 0;
        _tripAverageSpeed = 0;
        _tripAverageConsumptionByTime = 0;
        _tripAverageConsumptionByDistance = 0;
        _tripConsumption = 0;
        _actualConsumptionByTime = 0;
        _actualConsumptionByDistance = 0;
        _tripConsumptionByDistance = 0;
        _tripSpeed = 0;
    }

    private void FactoryConsumption()
    {
        for (int i = 0; i < 100; i++)
        {
            AddConsumption(4.8);
        }
    }

    private void AddConsumption(double consumption)
    {
        if (_recentConsumption.Count == 100)
        {
            _recentConsumption.Dequeue();
        }
        _recentConsumption.Enqueue(consumption);
    }
}