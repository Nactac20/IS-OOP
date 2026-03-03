using Lab1.TrainFiles;

namespace Lab1.PathFiles;

public class Station(double maxSpeed) : IPath
{
    private double MaxSpeed { get; set; } = maxSpeed;

    public bool LuckPuss(double precision, ITrain train)
    {
        if (train.GetSpeed() > MaxSpeed)
        {
            return false;
        }

        return true;
    }

    public double GetDuration()
    {
        return 0;
    }
}