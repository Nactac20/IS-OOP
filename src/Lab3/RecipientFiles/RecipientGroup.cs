using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

public class RecipientGroup : IRecipient
{
    private readonly List<IRecipient> _recipients = new List<IRecipient>();

    public void AddRecipient(IRecipient recipient)
    {
        _recipients.Add(recipient);
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}