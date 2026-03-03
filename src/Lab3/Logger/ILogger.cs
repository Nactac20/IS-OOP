using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public interface ILogger
{
    public void LogMessage(IMessage message);
}