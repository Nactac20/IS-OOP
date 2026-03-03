using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayFiles;

public interface IDisplay
{
    public void ShowMessage(IMessage message, ConsoleColor color);
}