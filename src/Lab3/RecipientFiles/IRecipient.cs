using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

public interface IRecipient
{
    void ReceiveMessage(IMessage message);
}