namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriverFiles;

public interface IDisplayDriver
{
    public void ClearDisplay();

    public void SetColor(ConsoleColor color);

    public void WriteText(string text);
}