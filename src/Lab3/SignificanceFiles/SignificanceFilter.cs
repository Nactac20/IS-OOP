using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.SignificanceFiles;

public class SignificanceFilter : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly SignificanceLevel _significanceLevel;

    public SignificanceFilter(IRecipient recipient, SignificanceLevel significanceLevel)
    {
        _recipient = recipient;
        _significanceLevel = significanceLevel;
    }

    public void ReceiveMessage(IMessage message)
    {
        if (message.GetLevel() >= _significanceLevel)
            _recipient.ReceiveMessage(message);
    }
}