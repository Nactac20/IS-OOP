namespace Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

public class RepositoryLectures
{
    private static readonly Lazy<RepositoryLectures> _instance = new Lazy<RepositoryLectures>(() => new RepositoryLectures());

    private Dictionary<int, string> LectureMaterials { get; set; } = new Dictionary<int, string>();

    private RepositoryLectures() { }

    public static RepositoryLectures Instance => _instance.Value;

    public void LectureMaterialsAdd(int id, string name)
    {
        LectureMaterials.Add(id, name);
    }

    public string LectureMaterialsGet(int id)
    {
        return LectureMaterials[id];
    }

    public int LectureMaterialsCount()
    {
        return LectureMaterials.Count;
    }

    public int? LectureMaterialsIdByNameGet(string name)
    {
        KeyValuePair<int, string> pair = LectureMaterials.FirstOrDefault(x => x.Value == name);
        return pair.Key == 0 ? null : pair.Key;
    }

    public void LectureMaterialsRemove(int id)
    {
        LectureMaterials.Remove(id);
    }

    public void LectureMaterialsClear()
    {
        LectureMaterials.Clear();
    }
}