using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.SystemDirectoryFiles;

public class SystemDirectory : ISystemDirectory
{
    public CommandResult ListDirectory(string pathway, int depth = 1)
    {
        if (!Directory.Exists(pathway)) return new CommandResult.Fail("Directory was not found");

        string[] directories = Directory.GetDirectories(pathway);
        string[] files = Directory.GetFiles(pathway);
        IEnumerable<string> items = directories.Select(dir => $"  {dir}").Concat(files.Select(file => $"  {file}"));
        string result = $"Directory: {pathway}\n{string.Join("\n", items)}";

        return new CommandResult.InfoMessage(result);
    }

    public CommandResult DeleteDirectory(string pathway)
    {
        if (!Directory.Exists(pathway)) return new CommandResult.Fail("Directory was not found");
        Directory.Delete(pathway, true);
        return new CommandResult.Success();
    }

    public CommandResult MoveDirectory(string pathway, string newPathway)
    {
        if (!Directory.Exists(pathway)) return new CommandResult.Fail("Directory was not found");
        if (Directory.Exists(newPathway)) return new CommandResult.InfoMessage("Directory already exists at the destination");
        Directory.Move(pathway, newPathway);
        return new CommandResult.Success();
    }

    public CommandResult RenameDirectory(string pathway, string newName)
    {
        if (!Directory.Exists(pathway)) return new CommandResult.Fail("Directory was not found");
        DirectoryInfo? parentDirectory = Directory.GetParent(pathway);

        if (parentDirectory == null) return new CommandResult.Fail("Cannot rename root directory");
        string newPathway = Path.Combine(parentDirectory.FullName, newName);

        Directory.Move(pathway, newPathway);
        return new CommandResult.Success();
    }

    public CommandResult CreateDirectory(string pathway)
    {
        if (Directory.Exists(pathway)) return new CommandResult.InfoMessage("Directory already exists");
        Directory.CreateDirectory(pathway);
        return new CommandResult.Success();
    }
}