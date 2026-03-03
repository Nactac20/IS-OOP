using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class RecipientLogging : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public RecipientLogging(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(IMessage message)
    {
        _logger.LogMessage(message);
        _recipient.ReceiveMessage(message);
    }
}