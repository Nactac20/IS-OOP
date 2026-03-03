using Itmo.ObjectOrientedProgramming.Lab3.SignificanceFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

public class Message : IMessage
{
    private string? Title { get; set; }

    private string? Body { get; set; }

    private int Id { get; set; }

    private SignificanceLevel SignificanceLevel { get; set; }

    public string? GetTitle()
    {
        return Title;
    }

    public string? GetBody()
    {
        return Body;
    }

    public int GetId()
    {
        return Id;
    }

    public SignificanceLevel GetLevel()
    {
        return SignificanceLevel;
    }

    public void SetTitle(string title)
    {
        Title = title;
    }

    public void SetBody(string body)
    {
        Body = body;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void SetLevel(SignificanceLevel level)
    {
        SignificanceLevel = level;
    }

    public Message(int id, string title, string body)
    {
        Id = id;
        Title = title;
        Body = body;
        SignificanceLevel = SignificanceLevel.Low;
    }

    public string MessageToString()
    {
        return $"{Title}\n{Body}";
    }
}