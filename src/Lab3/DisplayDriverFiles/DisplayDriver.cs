namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriverFiles;

public class DisplayDriver : IDisplayDriver
{
    private ConsoleColor _currentColor;

    public DisplayDriver()
    {
        _currentColor = ConsoleColor.White;
    }

    public void ClearDisplay()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        _currentColor = color;
    }

    public void WriteText(string text)
    {
        Console.ForegroundColor = _currentColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}