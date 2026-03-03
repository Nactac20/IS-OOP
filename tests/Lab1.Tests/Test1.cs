using Lab1.PathFiles;
using Lab1.RouteFiles;
using Lab1.TrainFiles;
using Xunit;

namespace Lab1.Tests;

public class Test1
{
    private readonly Route _route;
    private readonly ITrain _train;

    public Test1()
    {
        _route = new Route();
        _train = new Train(weight: 1000, speed: 0, accelaration: 0, maxForce: 5000);
    }

    [Fact]
    public void Test1_Success()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 4000));
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.True(result);
    }

    [Fact]
    public void Test2_Failure()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 6000));
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.False(result);
    }

    [Fact]
    public void Test3_Success()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 4000));
        _route.AddPath(new ConventMagneticPath(duration: 50));
        _route.AddPath(new Station(maxSpeed: 100));
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.True(result);
    }

    [Fact]
    public void Test4_Failure()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 6000));
        _route.AddPath(new Station(maxSpeed: 100));
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.False(result);
    }

    [Fact]
    public void Test5_Failure()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 6000));
        _route.AddPath(new ConventMagneticPath(duration: 50));
        _route.AddPath(new Station(maxSpeed: 100));
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.False(result);
    }

    [Fact]
    public void Test6_Success()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 4000));
        _route.AddPath(new ConventMagneticPath(duration: 50));
        _route.AddPath(new ForceMagneticPath(duration: 100, force: -2000));
        _route.AddPath(new Station(maxSpeed: 50));
        _route.AddPath(new ConventMagneticPath(duration: 50));
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 4000));
        _route.AddPath(new ConventMagneticPath(duration: 50));
        _route.AddPath(new ForceMagneticPath(duration: 100, force: -4000));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.True(result);
    }

    [Fact]
    public void Test7_Failure()
    {
        _route.AddPath(new ConventMagneticPath(duration: 50));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.False(result);
    }

    [Fact]
    public void Test8_Failure()
    {
        _route.AddPath(new ForceMagneticPath(duration: 100, force: 2000));
        _route.AddPath(new ForceMagneticPath(duration: 100, force: -4000));

        bool result = _route.LuckRoute(_train, precision: 0.1);
        Assert.False(result);
    }
}