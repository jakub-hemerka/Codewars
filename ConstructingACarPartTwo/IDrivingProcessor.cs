﻿namespace ConstructingACarPartTwo;
public interface IDrivingProcessor // car #2
{
    int ActualSpeed { get; }
    void IncreaseSpeedTo(int speed);
    void ReduceSpeed(int speed);
}