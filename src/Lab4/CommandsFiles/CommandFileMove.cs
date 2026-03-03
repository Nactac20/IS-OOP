using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandFileMove : ICommand
{
    private readonly string _sourcePath;
    private readonly string _destinationPath;

    public CommandFileMove(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public CommandResult Execute()
    {
        string fullSourcePath = StateSystem.Instance.GetFullPath(_sourcePath);
        string fullDestinationPath = StateSystem.Instance.GetFullPath(_destinationPath);

        if (!File.Exists(fullSourcePath))
        {
            return new CommandResult.Fail("Source file was not found");
        }

        if (!Directory.Exists(fullDestinationPath))
        {
            return new CommandResult.Fail("Destination directory was not found");
        }

        try
        {
            string fileName = Path.GetFileName(fullSourcePath);
            string newPath = Path.Combine(fullDestinationPath, fileName);
            File.Move(fullSourcePath, newPath);
            return new CommandResult.Success();
        }
        catch (Exception ex)
        {
            return new CommandResult.Fail($"Failed to move file: {ex.Message}");
        }
    }
}