namespace Lab1.TrainFiles;

public class Train(double weight, double speed, double accelaration, double maxForce) : ITrain
{
    private double Weight { get; set; } = weight;

    private double Speed { get; set; } = speed;

    private double Acceleration { get; set; } = accelaration;

    private double MaxForce { get; set; } = maxForce;

    public double GetSpeed()
    {
        return Speed;
    }

    public double GetAcceleration()
    {
        return Acceleration;
    }

    public double GetMaxForce()
    {
        return MaxForce;
    }

    public double GetWeight()
    {
        return Weight;
    }

    public bool ForceCalcult(double force)
    {
        if (force > MaxForce)
        {
            return false;
        }

        Acceleration = force / Weight;
        return true;
    }

    public double TimeDistanceCalcult(double distance, double precision)
    {
        double time = 0;
        if ((Speed == 0) & (Acceleration == 0))
        {
            throw new ErrorTimeExeption("Скорость и ускорение равны нулю");
        }

        if (distance <= 0)
        {
            throw new ErrorTimeExeption("Дистанция должна быть положительна");
        }

        while (distance > 0)
        {
            Speed += Acceleration * precision;
            if (Speed < 0)
            {
                throw new ErrorTimeExeption("Отрицательная скорость");
            }

            distance -= Speed * precision;

            time += precision;
        }

        return time;
    }
}