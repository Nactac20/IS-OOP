using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.SystemFiles;

public class SystemFile : ISystemFile
{
    public CommandResult CopyFile(string pathway, string newPathway)
    {
        if (!File.Exists(pathway)) return new CommandResult.Fail("File was not found");
        string? fileName = Path.GetFileName(pathway);

        newPathway = Path.Combine(newPathway, fileName);

        if (Path.Exists(pathway))
        {
            return new CommandResult.InfoMessage("File is already exists at the destination");
        }

        File.Copy(pathway, newPathway);
        return new CommandResult.Success();
    }

    public CommandResult DeleteFile(string pathway)
    {
        if (!File.Exists(pathway)) return new CommandResult.Fail("File was not found");
        File.Delete(pathway);
        return new CommandResult.Success();
    }

    public CommandResult MoveFile(string pathway, string newPathway)
    {
        if (!File.Exists(pathway)) return new CommandResult.Fail("File was not found");
        string? fileName = Path.GetFileName(pathway);

        newPathway = Path.Combine(newPathway, fileName);

        if (Path.Exists(pathway))
        {
            return new CommandResult.InfoMessage("File is already exists at the destination");
        }

        File.Move(pathway, newPathway);
        return new CommandResult.Success();
    }

    public CommandResult RenameFile(string pathway, string newName)
    {
        if (!File.Exists(pathway)) return new CommandResult.Fail("File was not found");
        string? directory = Path.GetDirectoryName(pathway);

        if (directory is null)
        {
            return new CommandResult.Fail("Directory was not found");
        }

        string newPathway = Path.Combine(directory, newName);

        File.Move(pathway, newPathway);
        return new CommandResult.Success();
    }
}