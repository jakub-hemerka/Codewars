# Constructing a car
## #2 - Driving

[Codewars URL](https://www.codewars.com/kata/578df8f3deaed98fcf0001e9)

You have to construct a car. Step by Step. Kata by Kata.

As second step you have to implement the logic for driving, which includes accelerating, braking and free-wheeling.

You have to consider all rules and conditions from the first car-Kata.

So you could use your code from the first car-Kata as base for this kata. Then insert the lines marked as comment "car #2".
(Also at the end of this text there are listed these new lines.)

New additional rules and conditions:
- If the car is free-wheeling (no pedal is used), it slows down the car by `1 km/h` by air resistance and rolling resistance.
- Braking is **BY** a speed. Accelerating is **TO** a speed. (Remember: Every call of a method from the car correlates to 1 second.)
- For every car the default acceleration is at most `10 km/h` per second.
- In a new further constructor of the car it should be possible to set a higher acceleration. The value has always to be in a range `from 5 to 20`. Correct if under minimum or above maximum.
- Every car brakes at most 10 km/h per second. (Very bad brakes, I know... This car would braking bad. :D)
- The maximum speed of a car is 250 km/h and of course it cannot have a negative speed.

The consumption for a driving car is be taken from these ranges:
```
1 - 60 km/h -> 0.0020 liter/second
61 - 100 km/h -> 0.0014 liter/second
101 - 140 km/h -> 0.0020 liter/second
141 - 200 km/h -> 0.0025 liter/second
201 - 250 km/h -> 0.0030 liter/second
```

(When the car brakes or freewheels with getting slower, there is no fuel consumption as in modern cars, when the car "powers" the engine.)

For convenience the accelerations and brakings are always linear and consumption is only for the speed at the end of every second. No considering on higher consumption while accelerating within a second.

In all tests only the whole car will be tested. Feel free to write your own tests for the other classes.

Under this text you will find the code of the interfaces.

```
public interface ICar
{
  bool EngineIsRunning { get; }        

  void BrakeBy(int speed); // car #2

  void Accelerate(int speed); // car #2

  void EngineStart();

  void EngineStop();

  void FreeWheel(); // car #2

  void Refuel(double liters);

  void RunningIdle();
}

public interface IDrivingInformationDisplay // car #2
{
  int ActualSpeed { get; }
}

public interface IDrivingProcessor // car #2
{
  int ActualSpeed { get; }

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
```
These are the new lines in the inital solution:
```
public class Car : ICar
{
  public IDrivingInformationDisplay drivingInformationDisplay; // car #2  

  private IDrivingProcessor drivingProcessor; // car #2
    
  public Car(double fuelLevel, int maxAcceleration) // car #2
  {

  }
}

public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
{

}

public class DrivingProcessor : IDrivingProcessor // car #2
{

}
```