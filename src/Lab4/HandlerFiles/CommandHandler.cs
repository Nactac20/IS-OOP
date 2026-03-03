using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public abstract class CommandHandler
{
    protected CommandHandler? NextHandler { get; private set; }

    public CommandHandler SetNext(CommandHandler handler)
    {
        NextHandler = handler;
        return handler;
    }

    public virtual CommandResult Handle(ICommand command)
    {
        if (NextHandler != null)
        {
            return NextHandler.Handle(command);
        }

        return new CommandResult.Fail("No handler found for the command.");
    }

    public virtual ICommand ParseCommand(string input)
    {
        if (NextHandler != null)
        {
            return NextHandler.ParseCommand(input);
        }

        throw new ArgumentException("Invalid command");
    }
}