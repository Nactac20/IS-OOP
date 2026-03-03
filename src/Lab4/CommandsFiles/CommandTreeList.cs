using Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;

public class CommandTreeList : ICommand
{
    private readonly string _pathway;
    private readonly int _depth;

    public CommandTreeList(string pathway, int depth)
    {
        _pathway = pathway;
        _depth = depth;
    }

    public CommandResult Execute()
    {
        string fullPath = StateSystem.Instance.GetFullPath(_pathway);

        if (!Directory.Exists(fullPath))
        {
            return new CommandResult.Fail("Directory was not found");
        }

        var result = new List<string>();
        ListDirectory(fullPath, _depth, result, string.Empty);

        return new CommandResult.InfoMessage(string.Join("\n", result));
    }

    private void ListDirectory(string path, int depth, List<string> result, string indent)
    {
        if (depth < 0) return;

        result.Add($"{indent}|- {new DirectoryInfo(path).Name}/");

        foreach (string file in Directory.GetFiles(path))
        {
            result.Add($"{indent}  |- {Path.GetFileName(file)}");
        }

        if (depth > 0)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                ListDirectory(directory, depth - 1, result, indent + "  ");
            }
        }
    }
}