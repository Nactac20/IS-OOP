using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandFileShow : ICommand
{
    private readonly string _pathway;
    private readonly string _mode;

    public CommandFileShow(string pathway, string mode)
    {
        _pathway = pathway;
        _mode = mode;
    }

    public CommandResult Execute()
    {
        string fullPath = StateSystem.Instance.GetFullPath(_pathway);

        if (!File.Exists(fullPath))
        {
            return new CommandResult.Fail("File was not found");
        }

        if (_mode != "console")
        {
            return new CommandResult.Fail("Unsupported mode");
        }

        string content = File.ReadAllText(fullPath);
        return new CommandResult.InfoMessage(content);
    }
}