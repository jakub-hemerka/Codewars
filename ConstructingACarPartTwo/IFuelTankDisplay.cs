﻿namespace ConstructingACarPartTwo;
public interface IFuelTankDisplay
{
    double FillLevel { get; }
    bool IsOnReserve { get; }
    bool IsComplete { get; }
}