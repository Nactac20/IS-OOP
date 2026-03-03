using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserFiles;

public interface IRecipientUser
{
    public void ReceiveMessage(IMessage message);

    public bool MarkMessageStatus(int messageId);
}