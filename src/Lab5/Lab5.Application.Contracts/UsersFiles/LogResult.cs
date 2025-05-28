namespace Lab5.Application.Contracts.UsersFiles;

public abstract record LogResult
{
    private LogResult() { }

    public sealed record Success : LogResult;

    public sealed record Failure : LogResult;
}