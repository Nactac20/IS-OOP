using Lab1.PathFiles;
using Lab1.TrainFiles;

namespace Lab1.RouteFiles;

public class Route : IRoute
{
    private readonly List<IPath> route = new();

    public bool LuckRoute(ITrain train, double precision)
    {
        for (int i = 0; i <= route.Count - 1; i++)
        {
            if (!route[i].LuckPuss(precision, train))
            {
                return false;
            }
        }

        return true;
    }

    public double TimeRoute(ITrain train, double precision)
    {
        double time = 0;
        for (int i = 0; i <= route.Count - 1; i++)
        {
            if (!route[i].LuckPuss(precision, train))
            {
                return 0;
            }

            time += train.TimeDistanceCalcult(route[i].GetDuration(), precision);
        }

        return time;
    }

    public void AddPath(IPath path)
    {
        route.Add(path);
    }
}