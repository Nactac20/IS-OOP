using Itmo.ObjectOrientedProgramming.Lab3.MessageFiles;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserFiles;

public class User : IRecipientUser
{
    private Dictionary<int, bool> Messages { get; set; } = new Dictionary<int, bool>();

    private int Id { get; set; }

    private string? Name { get; set; }

    public int GetId()
    {
        return Id;
    }

    public string? GetName()
    {
        return Name;
    }

    public void SetId(int id)
    {
        Id = id;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public Dictionary<int, bool> GetMessagesStatus()
    {
        return Messages;
    }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public bool SendMessage(int messageId)
    {
        if (!Messages.ContainsKey(messageId))
        {
            Messages[messageId] = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool MarkMessageStatus(int messageId)
    {
        if (Messages.ContainsKey(messageId))
        {
            if (!Messages[messageId])
            {
                Messages[messageId] = true;
                return true;
            }

            return false;
        }

        return false;
    }

    public void ReceiveMessage(IMessage message)
    {
        int messageId = message.GetId();
        if (!Messages.ContainsKey(messageId))
        {
            Messages[messageId] = false;
        }
    }
}
