namespace Itmo.ObjectOrientedProgramming.Lab2.ProgramFiles;

public class Program
{
    private static int _createId;

    private int? ID { get; set; }

    private string? NAME { get; set; }

    private int? ResPerson { get; set; }

    private int? Supervisor { get; set; }

    private Dictionary<int, List<int>> SubjectDictionarySemester { get; set; } = new Dictionary<int, List<int>>();

    public static Program CreateProgram(int id, string name, int resPerson, int supervisor)
    {
        return new Program(name, resPerson, supervisor);
    }

    public int? GetId()
    {
        return ID;
    }

    public string? GetName()
    {
        return NAME;
    }

    public int? GetResPerson()
    {
        return ResPerson;
    }

    public int? GetSupervisor()
    {
        return Supervisor;
    }

    public void SubjectDictionarySemesterAdd(int id, int semester)
    {
        SubjectDictionarySemester[id].Add(semester);
    }

    private static int GenId()
    {
        return _createId++;
    }

    public Program(string name, int resPerson, int supervisor)
    {
        ID = GenId();
        NAME = name;
        ResPerson = resPerson;
        Supervisor = supervisor;
    }

    public bool UpDateProgram(int currentId, string name, int resPerson, int supervisor)
    {
        if (currentId == supervisor)
        {
            NAME = name;
            ResPerson = resPerson;
            return true;
        }

        return false;
    }
}