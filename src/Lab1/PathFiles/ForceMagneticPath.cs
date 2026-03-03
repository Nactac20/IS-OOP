using Lab1.TrainFiles;

namespace Lab1.PathFiles;

public class ForceMagneticPath(double duration, double force) : IPath
{
    private double Duration { get; set; } = duration;

    private double Force { get; set; } = force;

    public double GetDuration()
    {
        return Duration;
    }

    public double GetForcePath()
    {
        return Force;
    }

    public bool LuckPuss(double precision, ITrain train)
    {
       try
       {
           if (train.ForceCalcult(Force))
           {
               double time = train.TimeDistanceCalcult(Duration, precision);
               return true;
           }
       }
       catch (ErrorTimeExeption)
       {
           return false;
       }

       return false;
     }
}