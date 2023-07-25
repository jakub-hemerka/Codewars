namespace ConstructingACarPartThree;
public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
{
    private readonly IDrivingProcessor _processor;

    public int ActualSpeed => _processor.ActualSpeed;

    public DrivingInformationDisplay(IDrivingProcessor processor)
    {
        _processor = processor;
    }
}