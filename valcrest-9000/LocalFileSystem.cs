namespace Valcrest9000;

public static class LocalFileSystem
{
    public static string AppLogs => EnsurePath(Path.Join(Directory.GetCurrentDirectory(), "res/app_log.txt"));
    public static string BotLogs => EnsurePath(Path.Join(Directory.GetCurrentDirectory(), "res/bot_log.txt"));
    public static string Config => EnsurePath(Path.Join(Directory.GetCurrentDirectory(), "res/config.json"));

    private static string EnsurePath(string filePath)
    {
        var info = new FileInfo(filePath);
        
        info.Directory!.Create();

        if (!info.Exists)
            info.Create().Dispose();

        return filePath;
    }
}