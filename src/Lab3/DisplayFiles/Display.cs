using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayFiles;

public class Display : IDisplay
{
    private IMessage _currentMessage;

    public Display(IMessage currentMessage)
    {
        _currentMessage = currentMessage;
    }

    public void ShowMessage(IMessage message, ConsoleColor color)
    {
        ClearDisplay();
        Console.ForegroundColor = color;
        Console.WriteLine(message.MessageToString());
        Console.ResetColor();
        _currentMessage = message;
    }

    private void ClearDisplay()
    {
        Console.Clear();
        if (_currentMessage != null)
        {
            Console.WriteLine(_currentMessage.MessageToString());
        }
    }
}