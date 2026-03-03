namespace Itmo.ObjectOrientedProgramming.Lab2.UserFiles;

public class RepositoryUser
{
    private static readonly Lazy<RepositoryUser> _instance = new Lazy<RepositoryUser>(() => new RepositoryUser());

    private Dictionary<int, string> UserDictionary { get; set; } = new Dictionary<int, string>();

    private RepositoryUser() { }

    public static RepositoryUser Instance => _instance.Value;

    public void UserAdd(int id, string name)
    {
        UserDictionary.Add(id, name);
    }

    public string UserGetId(int id)
    {
        return UserDictionary[id];
    }

    public int UsersCount()
    {
        return UserDictionary.Count;
    }

    public int? UsersIdByNameGet(string name)
    {
        KeyValuePair<int, string> pair = UserDictionary.FirstOrDefault(x => x.Value == name);
        return pair.Key == 0 ? null : pair.Key;
    }

    public void UserRemove(int id)
    {
        UserDictionary.Remove(id);
    }

    public void UserClear()
    {
        UserDictionary.Clear();
    }
}