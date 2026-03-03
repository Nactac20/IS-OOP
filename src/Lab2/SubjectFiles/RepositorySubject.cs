namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectFiles;

public class RepositorySubject
{
    private static readonly Lazy<RepositorySubject> _instance = new Lazy<RepositorySubject>(() => new RepositorySubject());

    private Dictionary<int, string> SubjectDictionary { get; set; } = new Dictionary<int, string>();

    private RepositorySubject() { }

    public static RepositorySubject Instance => _instance.Value;

    public void SubjectAdd(int id, string name)
    {
        SubjectDictionary.Add(id, name);
    }

    public string SubjectGet(int id)
    {
        return SubjectDictionary[id];
    }

    public int SubjectCount()
    {
        return SubjectDictionary.Count;
    }

    public int? SubjectIdByNameGet(string name)
    {
        KeyValuePair<int, string> pair = SubjectDictionary.FirstOrDefault(x => x.Value == name);
        return pair.Key == 0 ? null : pair.Key;
    }

    public void SubjectRemove(int id)
    {
        SubjectDictionary.Remove(id);
    }

    public void SubjectClear()
    {
        SubjectDictionary.Clear();
    }
}