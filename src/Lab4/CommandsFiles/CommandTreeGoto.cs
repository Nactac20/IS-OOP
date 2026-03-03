using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandTreeGoto : ICommand
{
    private readonly string _pathway;

    public CommandTreeGoto(string pathway)
    {
        _pathway = pathway;
    }

    public CommandResult Execute()
    {
        string fullPath = StateSystem.Instance.GetFullPath(_pathway);

        if (!Directory.Exists(fullPath))
        {
            return new CommandResult.Fail("Subdirectory was not found");
        }

        StateSystem.Instance.ChangeAbsolutePath(fullPath);
        return new CommandResult.Success();
    }
}