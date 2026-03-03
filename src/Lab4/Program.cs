using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

namespace Itmo.ObjectOrientedProgramming.Lab4;

internal class Program
{
    private static void Main(string[] args)
    {
        CommandHandler handler = HandlerChainBuilder.BuildHandlerChain();

        while (true)
        {
            Console.Write("Enter command: ");
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            ICommand? command = null;
            try
            {
                command = handler.ParseCommand(input);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                continue;
            }

            CommandResult result = handler.Handle(command);

            switch (result)
            {
                case CommandResult.Success:
                    Console.WriteLine("Command executed successfully.");
                    break;
                case CommandResult.Fail fail:
                    Console.WriteLine($"Command failed: {fail.ErrorMessage}");
                    break;
                case CommandResult.InfoMessage info:
                    Console.WriteLine(info.InMessage);
                    break;
            }
        }
    }
}