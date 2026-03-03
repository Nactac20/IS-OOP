using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandTreeGotoHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandTreeGoto treeGotoCommand)
        {
            return treeGotoCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "goto")
        {
            return base.ParseCommand(input);
        }

        string path = parts[2];
        return new CommandTreeGoto(path);
    }
}