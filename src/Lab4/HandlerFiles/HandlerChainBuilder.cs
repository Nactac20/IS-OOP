namespace Itmo.ObjectOrientedProgramming.Lab4.HandlerFiles;

public static class HandlerChainBuilder
{
    public static CommandHandler BuildHandlerChain()
    {
        CommandHandler connectHandler = new CommandConnectHandler();
        CommandHandler disconnectHandler = new CommandDisconnectHandler();
        CommandHandler treeGotoHandler = new CommandTreeGotoHandler();
        CommandHandler treeListHandler = new CommandTreeListHandler();
        CommandHandler fileShowHandler = new CommandFileShowHandler();
        CommandHandler fileMoveHandler = new CommandFileMoveHandler();
        CommandHandler fileCopyHandler = new CommandFileCopyHandler();
        CommandHandler fileDeleteHandler = new CommandFileDeleteHandler();
        CommandHandler fileRenameHandler = new CommandFileRenameHandler();

        connectHandler.SetNext(disconnectHandler)
            .SetNext(treeGotoHandler)
            .SetNext(treeListHandler)
            .SetNext(fileMoveHandler)
            .SetNext(fileCopyHandler)
            .SetNext(fileDeleteHandler)
            .SetNext(fileRenameHandler)
            .SetNext(fileShowHandler);

        return connectHandler;
    }
}