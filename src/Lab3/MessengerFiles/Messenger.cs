namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerFiles;

public class Messenger : IRecipientMessenger
{
    public void WriteMessage(string message)
    {
        Console.WriteLine($"Messenger: {message}");
    }
}