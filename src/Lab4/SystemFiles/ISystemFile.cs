using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.SystemFiles;

public interface ISystemFile
{
    public CommandResult CopyFile(string pathway, string newPathway);

    public CommandResult DeleteFile(string pathway);

    public CommandResult MoveFile(string pathway, string newPathway);

    public CommandResult RenameFile(string pathway, string newName);
}