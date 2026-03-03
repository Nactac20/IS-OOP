using Lab1.PathFiles;
using Lab1.TrainFiles;

namespace Lab1.RouteFiles;

public interface IRoute
{
    public bool LuckRoute(ITrain train, double precision);

    public void AddPath(IPath path);
}