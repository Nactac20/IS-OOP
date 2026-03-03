namespace Lab1.TrainFiles;

public interface ITrain
{
    public bool ForceCalcult(double force);

    public double TimeDistanceCalcult(double distance, double precision);

    public double GetSpeed();

    public double GetAcceleration();

    public double GetMaxForce();

    public double GetWeight();
}