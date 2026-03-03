namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public abstract record CommandResult()
{
    public sealed record Success : CommandResult;

    public record Fail(string ErrorMessage) : CommandResult;

    public record InfoMessage(string InMessage) : CommandResult;
}