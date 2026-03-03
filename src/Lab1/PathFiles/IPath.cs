using Lab1.TrainFiles;

namespace Lab1.PathFiles;

public interface IPath
{
    public bool LuckPuss(double precision, ITrain train);

    public double GetDuration();
}