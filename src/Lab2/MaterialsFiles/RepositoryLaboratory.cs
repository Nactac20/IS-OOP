namespace Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

public class RepositoryLaboratory
{
    private static readonly Lazy<RepositoryLaboratory> _instance = new Lazy<RepositoryLaboratory>(() => new RepositoryLaboratory());

    private Dictionary<int, string> LabWorks { get; set; } = new Dictionary<int, string>();

    private RepositoryLaboratory() { }

    public static RepositoryLaboratory Instance => _instance.Value;

    public void LabWorksAdd(int id, string name)
    {
        LabWorks.Add(id, name);
    }

    public string LabWorksGet(int id)
    {
        return LabWorks[id];
    }

    public int LabWorksCount()
    {
        return LabWorks.Count;
    }

    public int? LabWorksIdByNameGet(string name)
    {
        KeyValuePair<int, string> pair = LabWorks.FirstOrDefault(x => x.Value == name);
        return pair.Key == 0 ? null : pair.Key;
    }

    public void LabWorksRemove(int id)
    {
        LabWorks.Remove(id);
    }

    public void LabWorksClear()
    {
        LabWorks.Clear();
    }
}