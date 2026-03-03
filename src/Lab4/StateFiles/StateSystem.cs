using Itmo.ObjectOrientedProgramming.Lab4.SystemDirectoryFiles;
using Itmo.ObjectOrientedProgramming.Lab4.SystemFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

public class StateSystem : IStateSystem
{
    private static readonly Lazy<StateSystem> _instance = new Lazy<StateSystem>(() => new StateSystem());

    private StateSystem()
    {
        SystemFile = new SystemFile();
        SystemDirectory = new SystemDirectory();
        CurrentAbsolutePath = string.Empty;
    }

    public static StateSystem Instance => _instance.Value;

    public string CurrentAbsolutePath { get; private set; }

    public ISystemFile SystemFile { get; }

    public ISystemDirectory SystemDirectory { get; }

    public void ChangeDirectory(string subDirectory)
    {
        CurrentAbsolutePath = Path.Combine(CurrentAbsolutePath, subDirectory);
    }

    public void ChangeAbsolutePath(string absolutePath)
    {
        CurrentAbsolutePath = absolutePath;
    }

    public void Connect(string absolutePath)
    {
        CurrentAbsolutePath = absolutePath;
    }

    public void Disconnect()
    {
        CurrentAbsolutePath = string.Empty;
    }

    public void GotoAction(string path)
    {
        if (Path.IsPathRooted(path))
        {
            CurrentAbsolutePath = path;
        }
        else
        {
            CurrentAbsolutePath = Path.Combine(CurrentAbsolutePath, path);
        }
    }

    public string GetFullPath(string path)
    {
        if (Path.IsPathRooted(path))
        {
            return path;
        }

        return Path.Combine(CurrentAbsolutePath, path);
    }
}