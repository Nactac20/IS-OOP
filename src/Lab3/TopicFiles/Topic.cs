using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicFiles;

public class Topic : ITopic
{
    private static readonly Lazy<Topic> _instance = new Lazy<Topic>(() => new Topic());

    public static Topic Instance => _instance.Value;

    private readonly List<IRecipient> _recipients;

    private string? Name { get; set; }

    public Topic()
    {
        Name = null;
        _recipients = new List<IRecipient>();
    }

    public string? GetName()
    {
        return Name;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void RemoveRecipient(IRecipient recipient)
    {
        _recipients.Remove(recipient);
    }

    public void SendMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}