using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandFileRenameHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandFileRename fileRenameCommand)
        {
            return fileRenameCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "rename")
        {
            return base.ParseCommand(input);
        }

        string path = parts[2];
        string newName = parts[3];
        return new CommandFileRename(path, newName);
    }
}