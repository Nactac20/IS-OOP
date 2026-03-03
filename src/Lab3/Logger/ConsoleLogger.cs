using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class ConsoleLogger : ILogger
{
    public void LogMessage(IMessage message)
    {
        Console.WriteLine($"Log: {message.MessageToString()}");
    }
}