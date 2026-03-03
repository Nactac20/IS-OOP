using Lab1.TrainFiles;

namespace Lab1.PathFiles;

public class ConventMagneticPath(double duration) : IPath
{
    private double Duration { get; set; } = duration;

    public double GetDuration()
    {
        return Duration;
    }

    public bool LuckPuss(double precision, ITrain train)
    {
        try
        {
            double time = train.TimeDistanceCalcult(Duration, precision);
            return true;
        }
        catch (ErrorTimeExeption)
        {
            return false;
        }
    }
}