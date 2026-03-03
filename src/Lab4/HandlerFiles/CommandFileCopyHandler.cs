using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandFileCopyHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandFileCopy fileCopyCommand)
        {
            return fileCopyCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "copy")
        {
            return base.ParseCommand(input);
        }

        string sourcePath = parts[2];
        string destinationPath = parts[3];
        return new CommandFileCopy(sourcePath, destinationPath);
    }
}