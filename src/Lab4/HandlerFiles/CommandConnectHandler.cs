using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public class CommandConnectHandler : CommandHandler
{
    public override CommandResult Handle(ICommand command)
    {
        if (command is CommandConnect connectCommand)
        {
            return connectCommand.Execute();
        }

        return base.Handle(command);
    }

    public override ICommand ParseCommand(string input)
    {
        string[] parts = input.Split(' ');
        if (parts.Length < 2 || parts[0] != "connect")
        {
            return base.ParseCommand(input);
        }

        string address = parts[1];

        string? mode = string.Empty;
        if (parts.Length == 4)
        {
            mode = parts[3];
        }

        return new CommandConnect(address, mode);
    }
}