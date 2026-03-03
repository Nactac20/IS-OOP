using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandFileRename : ICommand
{
    private readonly string _pathway;
    private readonly string _newName;

    public CommandFileRename(string pathway, string newName)
    {
        _pathway = pathway;
        _newName = newName;
    }

    public CommandResult Execute()
    {
        string fullPath = StateSystem.Instance.GetFullPath(_pathway);

        if (!File.Exists(fullPath))
        {
            return new CommandResult.Fail("File was not found");
        }

        string? directory = Path.GetDirectoryName(fullPath);
        if (directory == null)
        {
            return new CommandResult.Fail("Directory was not found or is invalid");
        }

        string newPath = Path.Combine(directory, _newName);

        try
        {
            File.Move(fullPath, newPath);
            return new CommandResult.Success();
        }
        catch (Exception ex)
        {
            return new CommandResult.Fail($"Failed to rename file: {ex.Message}");
        }
    }
}