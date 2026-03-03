namespace Lab1.TrainFiles;

public class ErrorTimeExeption : Exception
{
    public ErrorTimeExeption() : base("Невозможно вычислить время")
    {
    }

    public ErrorTimeExeption(string message) : base(message)
    {
    }

    public ErrorTimeExeption(string message, Exception innerException) : base(message, innerException)
    {
    }
}