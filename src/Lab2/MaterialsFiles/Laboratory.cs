namespace Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

public class Laboratory
{
    private static int _createId;

    private int ID { get; set; }

    private string NAME { get; set; }

    private string DESCRIPTION { get; set; }

    private string CRITERION { get; set; }

    private int POINTS { get; set; }

    private int? IdAuthor { get; set; }

    private int? IdParent { get; set; }

    public int GetId()
    {
        return ID;
    }

    public string GetName()
    {
        return NAME;
    }

    public string GetDescription()
    {
        return DESCRIPTION;
    }

    public string GetCriterion()
    {
        return CRITERION;
    }

    public int GetPoints()
    {
        return POINTS;
    }

    public int? GetAuthor()
    {
        return IdAuthor;
    }

    public int? GetParent()
    {
        return IdParent;
    }

    private static int GenId()
    {
        return _createId++;
    }

    public Laboratory(string name, string description, string criterion, int points)
    {
        ID = GenId();
        NAME = name;
        DESCRIPTION = description;
        CRITERION = criterion;
        POINTS = points;
    }

    public static Laboratory CreateLab(int id, string name, string description, string criterion, int points)
    {
        return new Laboratory(name, description, criterion, points);
    }

    public void SetAuthor(int id)
    {
        this.IdAuthor = id;
    }

    public bool UpDateLab(int currentId, string name, string description, string criterion)
    {
        if (currentId == IdAuthor)
        {
            NAME = name;
            DESCRIPTION = description;
            CRITERION = criterion;
            return true;
        }

        return false;
    }

    public Laboratory CloneLab()
    {
        return new Laboratory(NAME, DESCRIPTION, CRITERION, POINTS)
        {
            ID = GenId(),
            IdParent = ID,
            NAME = NAME,
            DESCRIPTION = DESCRIPTION,
            CRITERION = CRITERION,
            POINTS = POINTS,
        };
    }
}