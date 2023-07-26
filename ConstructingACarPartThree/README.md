# Constructing a car
## #3 - On-Board Computer

[Codewars URL](https://www.codewars.com/kata/57961d4e4be9121ec90001bd)

You have to construct a car. Step by Step. Kata by Kata.

As third step you have to implement the logic for an "on-board computer" (a.k.a. "body computer module" (bcm) or "Bordcomputer").

You have to consider all rules and conditions from the previous car-Katas.

So you could use your code from the last car-Kata as base for this kata. Then insert the lines marked as comment "car #3"
(Also at the end of this text there are listed these new lines.)

New additional rules and conditions:
- The On-Board Computer should display the following informations:
  - trip real time
  - trip driving time
  - total real time
  - total driving time
  - trip driven distance
  - total driven distance
  - actual speed (additional to the drivingInformationDisplay)
  - trip average speed
  - total average speed
  - actual consumption by time (from the last second/method)
  - actual consumption by distance (from the last second/method)
  - trip average consumption by time
  - total average consumption by time
  - trip average consumption by distance
  - total average consumption by distance
  - estimated range with actual fuel level
- "trip" means since enginestart. The "total"-counter keep their values beyond enginestarts.
- The On-Board Computer should be resetable for the "trip" and for "total".
- The speed-average-values are calculated by driving time (km/h) and should be rounded for `1 decimal place`.
- The actual-consumption-by-time is calculated by second and should be rounded for `5 decimal places`.
- The actual-consumption-by-distance is calculated in `liter/100 km` and should be rounded for `1 decimal place`. If the car does not drive, it should return NaN.
- The consumption-average-by-time-values are calculated by real time (liter/second) and should be rounded for `5 decimal places`.
- The consumption-average-by-distance-values are calculated in `liter/100 km` and should be rounded for `1 decimal place`.
- The driving-distance-values are calculated in km and should have at max `2 decimal places`.
- The estimated-range should be calculated in km and base on the consumption of the last 100 seconds. When the car is built, it should be assumed that the consumption was 4.8 Liter for the last 100 seconds.

**Hint: Also the values actual-consumption-by-distance and consumption-average-by-distance are calculated every second! (They are NOT calculated e.g. every 1 km or 10km. This would be much more realistic but would also make this kata much more complicated!)**

Remember: Every call of a method (except Refuel :D) from the car correlates to 1 second. Methods from the On-Board Computer correlates to 0 seconds.

**Hint: The methods "EngineStart" and "EngineStop" of the DrivingProcessor do NOT start the engine, but give the event into the DrivingProcessor, that the engine has started or stopped.**

Under this text you will find the code of the interfaces.

```cs
public interface ICar
{
    bool EngineIsRunning { get; }        

    void BrakeBy(int speed);

    void Accelerate(int speed);

    void EngineStart();

    void EngineStop();

    void FreeWheel();   

    void Refuel(double liters);

    void RunningIdle();
}

public interface IDrivingInformationDisplay
{
    int ActualSpeed { get; }
}

public interface IDrivingProcessor
{
    double ActualConsumption { get; } // car #3

    int ActualSpeed { get; }

    void EngineStart(); // car #3

    void EngineStop(); // car #3

    void IncreaseSpeedTo(int speed);

    void ReduceSpeed(int speed);
}

public interface IEngine
{
    bool IsRunning { get; }

    void Consume(double liters);

    void Start();

    void Stop();
}

public interface IFuelTank
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }

    void Consume(double liters);

    void Refuel(double liters);        
}

public interface IFuelTankDisplay
{
    double FillLevel { get; }

    bool IsOnReserve { get; }

    bool IsComplete { get; }
}

public interface IOnBoardComputer // car #3
{
    int TripRealTime { get; }

    int TripDrivingTime { get; }

    int TripDrivenDistance { get; }

    int TotalRealTime { get; }

    int TotalDrivingTime { get; }

    int TotalDrivenDistance { get; }

    double TripAverageSpeed { get; }

    double TotalAverageSpeed { get; }

    int ActualSpeed { get; }

    double ActualConsumptionByTime { get; }

    double ActualConsumptionByDistance { get; }

    double TripAverageConsumptionByTime { get; }

    double TotalAverageConsumptionByTime { get; }

    double TripAverageConsumptionByDistance { get; }

    double TotalAverageConsumptionByDistance { get; }

    int EstimatedRange { get; }

    void ElapseSecond();

    void TripReset();

    void TotalReset();
}

public interface IOnBoardComputerDisplay // car #3
{
    int TripRealTime { get; }

    int TripDrivingTime { get; }

    double TripDrivenDistance { get; }

    int TotalRealTime { get; }

    int TotalDrivingTime { get; }

    double TotalDrivenDistance { get; }

    int ActualSpeed { get; }

    double TripAverageSpeed { get; }

    double TotalAverageSpeed { get; }

    double ActualConsumptionByTime { get; }

    double ActualConsumptionByDistance { get; }

    double TripAverageConsumptionByTime { get; }

    double TotalAverageConsumptionByTime { get; }

    double TripAverageConsumptionByDistance { get; }

    double TotalAverageConsumptionByDistance { get; }

    int EstimatedRange { get; }

    void TripReset();

    void TotalReset();
}
```
These are the new lines in the inital solution:
```cs
public class Car : ICar
{
    public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

    private IOnBoardComputer onBoardComputer; // car #3
}

public class OnBoardComputer : IOnBoardComputer // car #3
{

}

public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
{

}
```