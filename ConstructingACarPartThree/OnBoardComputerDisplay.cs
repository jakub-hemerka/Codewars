namespace ConstructingACarPartThree;
public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
{
    private readonly IOnBoardComputer _onBoardComputer;

    public int TripRealTime => _onBoardComputer.TripRealTime;
    public int TripDrivingTime => _onBoardComputer.TripDrivingTime;
    public double TripDrivenDistance => ConvertToKilometersPerSecond(_onBoardComputer.TripDrivenDistance);
    public int TotalRealTime => _onBoardComputer.TotalRealTime;
    public int TotalDrivingTime => _onBoardComputer.TotalDrivingTime;
    public double TotalDrivenDistance => ConvertToKilometersPerSecond(_onBoardComputer.TotalDrivenDistance);
    public int ActualSpeed => _onBoardComputer.ActualSpeed;
    public double TripAverageSpeed => Math.Round(_onBoardComputer.TripAverageSpeed, 1, MidpointRounding.AwayFromZero);
    public double TotalAverageSpeed => Math.Round(_onBoardComputer.TotalAverageSpeed, 1, MidpointRounding.AwayFromZero);
    public double ActualConsumptionByTime => Math.Round(_onBoardComputer.ActualConsumptionByTime, 5, MidpointRounding.AwayFromZero);
    public double ActualConsumptionByDistance => Math.Round(_onBoardComputer.ActualConsumptionByDistance, 1, MidpointRounding.AwayFromZero);
    public double TripAverageConsumptionByTime => Math.Round(_onBoardComputer.TripAverageConsumptionByTime, 5, MidpointRounding.AwayFromZero);
    public double TotalAverageConsumptionByTime => Math.Round(_onBoardComputer.TotalAverageConsumptionByTime, 5, MidpointRounding.AwayFromZero);
    public double TripAverageConsumptionByDistance => Math.Round(_onBoardComputer.TripAverageConsumptionByDistance, 1, MidpointRounding.AwayFromZero);
    public double TotalAverageConsumptionByDistance => Math.Round(_onBoardComputer.TotalAverageConsumptionByDistance, 1, MidpointRounding.AwayFromZero);
    public int EstimatedRange => _onBoardComputer.EstimatedRange;

    public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
    {
        _onBoardComputer = onBoardComputer;
    }

    private double ConvertToKilometersPerSecond(int kilometersPerHour)
    {
        double result = kilometersPerHour * (1 / 3600d);
        return Math.Round(result, 2, MidpointRounding.AwayFromZero);
    }

    public void TotalReset()
    {
        _onBoardComputer.TotalReset();
    }

    public void TripReset()
    {
        _onBoardComputer.TripReset();
    }
}