using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandFileDelete : ICommand
{
    private readonly string _pathway;

    public CommandFileDelete(string pathway)
    {
        _pathway = pathway;
    }

    public CommandResult Execute()
    {
        string fullPath = StateSystem.Instance.GetFullPath(_pathway);

        if (!File.Exists(fullPath))
        {
            return new CommandResult.Fail("File was not found");
        }

        try
        {
            File.Delete(fullPath);
            return new CommandResult.Success();
        }
        catch (Exception ex)
        {
            return new CommandResult.Fail($"Failed to delete file: {ex.Message}");
        }
    }
}