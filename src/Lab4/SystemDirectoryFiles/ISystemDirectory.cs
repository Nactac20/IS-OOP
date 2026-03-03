using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.SystemDirectoryFiles;

public interface ISystemDirectory
{
    public CommandResult ListDirectory(string pathway, int depth = 1);

    public CommandResult DeleteDirectory(string pathway);

    public CommandResult MoveDirectory(string pathway, string newPathway);

    public CommandResult RenameDirectory(string pathway, string newName);

    public CommandResult CreateDirectory(string pathway);
}