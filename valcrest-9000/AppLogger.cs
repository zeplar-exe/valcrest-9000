namespace Valcrest9000;

public class AppLogger : IDisposable
{
    private StreamWriter Writer { get; }

    public AppLogger()
    {
        Writer = new StreamWriter(LocalFileSystem.AppLogs, true);
    }

    public async void WriteLine(string text)
    {
        await Writer.WriteLineAsync(text);
    }
    
    public void Dispose()
    {
        Writer.Dispose();
    }
}