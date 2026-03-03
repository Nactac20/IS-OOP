using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandConnect : ICommand
{
    private readonly string _address;
    private readonly string _mode;

    public CommandConnect(string address, string mode)
    {
        _address = address;
        _mode = mode;
    }

    public CommandResult Execute()
    {
        if (_mode != "local" && !string.IsNullOrEmpty(_mode))
        {
            return new CommandResult.Fail("Unsupported file system mode");
        }

        if (!Directory.Exists(_address))
        {
            return new CommandResult.Fail("Directory was not found");
        }

        StateSystem.Instance.Connect(_address);
        return new CommandResult.Success();
    }
}