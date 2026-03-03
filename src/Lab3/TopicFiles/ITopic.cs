using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicFiles;

public interface ITopic
{
    public string? GetName();

    public void SetName(string name);

    public void AddRecipient(IRecipient recipient);

    public void RemoveRecipient(IRecipient recipient);

    public void SendMessage(IMessage message);
}