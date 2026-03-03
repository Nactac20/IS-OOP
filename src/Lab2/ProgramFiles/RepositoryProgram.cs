namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramFiles;

public class RepositoryProgram
{
    private static readonly Lazy<RepositoryProgram> _instance = new Lazy<RepositoryProgram>(() => new RepositoryProgram());

    private Dictionary<int, List<int>> SubjectDictionarySemester { get; set; } = new Dictionary<int, List<int>>();

    private RepositoryProgram() { }

    public static RepositoryProgram Instance => _instance.Value;

    public void ProgramAdd(int id, int semester)
    {
        SubjectDictionarySemester[id].Add(semester);
    }

    public int ProgramGet(int id, int semester)
    {
        return SubjectDictionarySemester[id][semester];
    }

    public int ProgramCount()
    {
        return SubjectDictionarySemester.Count;
    }

    public void SubjectRemove(int id, int semester)
    {
        SubjectDictionarySemester[id].Remove(semester);
    }
}