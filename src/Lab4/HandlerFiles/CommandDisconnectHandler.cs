using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandDisconnectHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandDisconnect disconnectCommand)
        {
            return disconnectCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length != 1 || parts[0] != "disconnect")
        {
            return base.ParseCommand(input);
        }

        return new CommandDisconnect();
    }
}