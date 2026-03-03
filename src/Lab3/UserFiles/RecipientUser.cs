using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserFiles;

public class RecipientUser : IRecipient
{
    private readonly IRecipientUser _user;

    public RecipientUser(IRecipientUser user)
    {
        _user = user;
    }

    public bool MarkMessageStatus(int messageId)
    {
        return _user.MarkMessageStatus(messageId);
    }

    public void ReceiveMessage(IMessage? message)
    {
        if (message is not null)
        {
            _user.ReceiveMessage(message);
        }
    }
}