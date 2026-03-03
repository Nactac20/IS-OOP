namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectFiles;

public class Subject
{
    private static int _createId;

    private int? ID { get; set; }

    private string? NAME { get; set; }

    private int? IdAuthor { get; set; }

    private Dictionary<int, string> LabWorks { get; set; } = [];

    private Dictionary<int, string> LectureMaterials { get; set; } = [];

    private int? IdParent { get; set; }

    private int? ExamPoints { get; set; }

    private int? PassPoints { get; set; }

    private int? SumPoints { get; set; }

    public int? GetId()
    {
        return ID;
    }

    public string? GetName()
    {
        return NAME;
    }

    public int? GetAuthor()
    {
        return IdAuthor;
    }

    public int? GetParent()
    {
        return IdParent;
    }

    public int? GetExamPoints()
    {
        return ExamPoints;
    }

    public int? GetPassPoints()
    {
        return PassPoints;
    }

    public int? GetSumPoints()
    {
        return SumPoints;
    }

    public void AddLabWorks(Dictionary<int, string> labWorks)
    {
        LabWorks = labWorks;
    }

    public void AddLecMat(Dictionary<int, string> lecMat)
    {
        LectureMaterials = lecMat;
    }

    public string SetLabName(int id)
    {
        return LabWorks[id];
    }

    public string SetLecName(int id)
    {
        return LectureMaterials[id];
    }

    public void SetName(string name)
    {
        NAME = name;
    }

    public void SetIdAuthor(int id)
    {
        IdAuthor = id;
    }

    public void SetIdParent(int id)
    {
        IdParent = id;
    }

    public void SetExamPoints(int ePoints)
    {
        ExamPoints = ePoints;
    }

    public void SetPassPoints(int pPoints)
    {
        PassPoints = pPoints;
    }

    public void SetSumPoints(int sumPoints)
    {
        SumPoints = sumPoints;
    }

    public Subject(Dictionary<int, string> labWorks, Dictionary<int, string> lectureMaterials)
    {
        ID = GenId();
        LabWorks = labWorks;
        LectureMaterials = lectureMaterials;
    }

    private static int GenId()
    {
        return _createId++;
    }
}