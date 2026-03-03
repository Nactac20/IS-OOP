using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandFileShowHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandFileShow fileShowCommand)
        {
            return fileShowCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 3 || parts[0] != "file" || parts[1] != "show")
        {
            base.ParseCommand(input);
        }

        string path = parts[2];
        string mode = "console";
        if (parts.Length > 3 && parts[3] == "-m")
        {
            mode = parts[4];
        }

        return new CommandFileShow(path, mode);
    }
}