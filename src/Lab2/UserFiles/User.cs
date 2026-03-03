namespace Itmo.ObjectOrientedProgramming.Lab2.UserFiles;

public class User
{
    private static int _createId;

    private int? ID { get; set; }

    private string? NAME { get; set; }

    public int? GetId()
    {
        return ID;
    }

    public string? GetName()
    {
        return NAME;
    }

    private static int GenId()
    {
        return _createId++;
    }

    public User(string name)
    {
        ID = GenId();
        NAME = name;
    }

    public static User CreateUser(int id, string name)
    {
        return new User(name);
    }
}