using Itmo.ObjectOrientedProgramming.Lab3.SignificanceFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

public interface IMessage
{
    public string? GetBody();

    public string? GetTitle();

    public int GetId();

    public SignificanceLevel GetLevel();

    public void SetTitle(string title);

    public void SetBody(string body);

    public void SetId(int id);

    public void SetLevel(SignificanceLevel level);

    public string MessageToString();
}