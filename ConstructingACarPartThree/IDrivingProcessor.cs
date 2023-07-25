namespace ConstructingACarPartThree;
public interface IDrivingProcessor // car #2
{
    double ActualConsumption { get; } // car #3
    int ActualSpeed { get; }
    void EngineStart(); // car #3
    void EngineStop(); // car #3
    void IncreaseSpeedTo(int speed);
    void ReduceSpeed(int speed);
}