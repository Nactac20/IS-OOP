using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandTreeListHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandTreeList treeListCommand)
        {
            return treeListCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 3 || parts[0] != "tree" || parts[1] != "list")
        {
            return base.ParseCommand(input);
        }

        string path = parts[2];
        int depth = 1;
        if (parts.Length > 3 && parts[3] == "-d")
        {
            depth = int.Parse(parts[4]);
        }

        return new CommandTreeList(path, depth);
    }
}