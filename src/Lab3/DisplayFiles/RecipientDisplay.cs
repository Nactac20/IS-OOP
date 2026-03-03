using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;
using Itmo.ObjectOrientedProgramming.Lab3.RecipientFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayFiles;

public class RecipientDisplay : IRecipient
{
    private readonly IDisplay _display;

    public RecipientDisplay(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(IMessage message)
    {
        _display.ShowMessage(message, ConsoleColor.White);
    }
}