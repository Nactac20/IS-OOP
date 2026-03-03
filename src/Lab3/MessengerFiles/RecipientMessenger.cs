using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerFiles;

public class RecipientMessenger(IRecipientMessenger recipientMessenger) : IRecipient
{
    public void ReceiveMessage(IMessage message)
    {
        recipientMessenger.WriteMessage(message.MessageToString());
    }
}