using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandDisconnect : ICommand
{
    public CommandResult Execute()
    {
        StateSystem.Instance.Disconnect();
        return new CommandResult.Success();
    }
}