using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void LogMessage(IMessage message)
    {
        File.AppendAllText(_filePath, $"Log: {message.MessageToString()}\n");
    }
}