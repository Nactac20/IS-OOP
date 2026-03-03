using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandFileMoveHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandFileMove fileMoveCommand)
        {
            return fileMoveCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 4 || parts[0] != "file" || parts[1] != "move")
        {
            return base.ParseCommand(input);
        }

        string sourcePath = parts[2];
        string destinationPath = parts[3];
        return new CommandFileMove(sourcePath, destinationPath);
    }
}