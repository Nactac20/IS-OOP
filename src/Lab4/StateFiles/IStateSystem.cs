using Itmo.ObjectOrientedProgramming.Lab4.SystemDirectoryFiles;
using Itmo.ObjectOrientedProgramming.Lab4.SystemFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4.StateFiles;

public interface IStateSystem
{
    string CurrentAbsolutePath { get; }

    ISystemFile SystemFile { get; }

    ISystemDirectory SystemDirectory { get; }

    void ChangeDirectory(string subDirectory);

    void ChangeAbsolutePath(string absolutePath);

    void Connect(string absolutePath);

    void Disconnect();

    void GotoAction(string path);

    public string GetFullPath(string path);
}