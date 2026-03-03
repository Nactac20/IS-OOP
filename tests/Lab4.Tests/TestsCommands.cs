using Itmo.ObjectOrientedProgramming.Lab4.CommandsFiles;
using Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;
using Xunit;

namespace Lab4.Tests;

public class TestsCommands
{
    private readonly CommandHandler _handler;
    private readonly string _testDirectory;

    public TestsCommands()
    {
        _handler = HandlerChainBuilder.BuildHandlerChain();
        _testDirectory = Path.Combine(Path.GetTempPath(), "Lab4TestDirectory");
        Directory.CreateDirectory(_testDirectory);
    }

    [Fact]
    public void TestConnectCommand()
    {
        ICommand command = new CommandConnectHandler().ParseCommand($"connect {_testDirectory} local");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.Success>(result);
    }

    [Fact]
    public void TestDisconnectCommand()
    {
        ICommand command = new CommandDisconnectHandler().ParseCommand("disconnect");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.Success>(result);
    }

    [Fact]
    public void TestTreeGotoCommand()
    {
        ICommand command = new CommandTreeGotoHandler().ParseCommand($"tree goto {_testDirectory}");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.Success>(result);
    }

    [Fact]
    public void TestTreeListCommand()
    {
        ICommand command = new CommandTreeListHandler().ParseCommand($"tree list {_testDirectory} -d 1");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.InfoMessage>(result);
    }

    [Fact]
    public void TestFileShowCommand()
    {
        string testFilePath = Path.Combine(_testDirectory, "test.txt");
        File.WriteAllText(testFilePath, "Hello, World!");

        ICommand command = new CommandFileShowHandler().ParseCommand($"file show {testFilePath} -m console");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.InfoMessage>(result);
        Assert.Equal("Hello, World!", ((CommandResult.InfoMessage)result).InMessage);
    }

    [Fact]
    public void TestFileDeleteCommand()
    {
        string filePath = Path.Combine(_testDirectory, "test.txt");
        File.WriteAllText(filePath, "Hello, World!");

        ICommand command = new CommandFileDeleteHandler().ParseCommand($"file delete {filePath}");
        CommandResult result = _handler.Handle(command);
        Assert.IsType<CommandResult.Success>(result);
        Assert.False(File.Exists(filePath));
    }

    [Fact]
    public void TestFileMoveCommand_SourceFileDoesNotExist()
    {
        string sourceFilePath = Path.Combine(_testDirectory, "nonexistent.txt");
        string destinationDirectory = Path.Combine(_testDirectory, "subdir");
        Directory.CreateDirectory(destinationDirectory);

        ICommand command = new CommandFileMoveHandler().ParseCommand($"file move {sourceFilePath} {destinationDirectory}");
        CommandResult result = _handler.Handle(command);
        Assert.True(result is CommandResult.Fail);
        Assert.False(File.Exists(sourceFilePath));
        Assert.False(File.Exists(Path.Combine(destinationDirectory, "nonexistent.txt")));
    }

    [Fact]
    public void TestFileCopyCommand_DestinationDirectoryDoesNotExist()
    {
        string sourceFilePath = Path.Combine(_testDirectory, "test.txt");
        string destinationDirectory = Path.Combine(_testDirectory, "nonexistent_dir");
        File.WriteAllText(sourceFilePath, "Hello, World!");

        ICommand command = new CommandFileCopyHandler().ParseCommand($"file copy {sourceFilePath} {destinationDirectory}");
        CommandResult result = _handler.Handle(command);
        Assert.True(result is CommandResult.Fail);
        Assert.True(File.Exists(sourceFilePath));
        Assert.False(Directory.Exists(destinationDirectory));
    }

    [Fact]
    public void TestFileRenameCommand_NewFileNameAlreadyExists()
    {
        string sourceFilePath = Path.Combine(_testDirectory, "test.txt");
        string newFileName = "existing.txt";
        File.WriteAllText(sourceFilePath, "Hello, World!");
        File.WriteAllText(Path.Combine(_testDirectory, newFileName), "Existing content");

        ICommand command = new CommandFileRenameHandler().ParseCommand($"file rename {sourceFilePath} {newFileName}");
        CommandResult result = _handler.Handle(command);
        Assert.True(result is CommandResult.Fail);
        Assert.True(File.Exists(sourceFilePath));
        Assert.True(File.Exists(Path.Combine(_testDirectory, newFileName)));
    }
}