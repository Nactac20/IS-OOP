namespace Itmo.ObjectOrientedProgramming.Lab2.MaterialsFiles;

public class Lectures
{
    private static int _createId;

    private int ID { get; set; }

    private string NAME { get; set; }

    private string DESCRIPTION { get; set; }

    private string CONTENT { get; set; }

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

    public string GetContent()
    {
        return CONTENT;
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

    public Lectures(string name, string description, string content)
    {
        ID = GenId();
        NAME = name;
        DESCRIPTION = description;
        CONTENT = content;
    }

    public static Lectures CreateLec(int id, string name, string description, string content)
    {
        return new Lectures(name, description, content);
    }

    public void SetAuthor(int id)
    {
        this.IdAuthor = id;
    }

    public bool UpDateLec(int currentId, string name, string description, string content)
    {
        if (currentId == IdAuthor)
        {
            NAME = name;
            DESCRIPTION = description;
            CONTENT = content;
            return true;
        }

        return false;
    }

    public Lectures CloneLec()
    {
        return new Lectures(NAME, DESCRIPTION, CONTENT)
        {
            ID = GenId(),
            IdParent = ID,
            NAME = NAME,
            DESCRIPTION = DESCRIPTION,
            CONTENT = CONTENT,
        };
    }
}