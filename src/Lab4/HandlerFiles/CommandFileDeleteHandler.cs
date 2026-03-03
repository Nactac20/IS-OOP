using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandFileDeleteHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandFileDelete fileDeleteCommand)
        {
            return fileDeleteCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "delete")
        {
            return base.ParseCommand(input);
        }

        string path = parts[2];
        return new CommandFileDelete(path);
    }
}