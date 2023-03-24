namespace Valcrest9000;

public class BotLogger : IDisposable
{
    private StreamWriter Writer { get; }

    public BotLogger()
    {
        Writer = new StreamWriter(LocalFileSystem.BotLogs, true);
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