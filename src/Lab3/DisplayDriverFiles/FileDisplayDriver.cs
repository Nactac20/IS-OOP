namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriverFiles;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void ClearDisplay()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetColor(ConsoleColor color)
    {
    }

    public void WriteText(string text)
    {
        File.AppendAllText(_filePath, text + "\n");
    }
}