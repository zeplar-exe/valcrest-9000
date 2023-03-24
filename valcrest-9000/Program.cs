using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Valcrest9000.Commands;

namespace Valcrest9000;

public static class Program
{
    private static DiscordSocketClient Client { get; set; }
    
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Readying Services");
        await using var services = ConfigureServices();
        
        Client = services.GetRequiredService<DiscordSocketClient>();
        Client.Log += OnClientLog;
        
        Console.WriteLine("Logging in");

        await Client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("BOT_TOKEN"));
        await Client.StartAsync();

        await services.GetRequiredService<CommandHandler>().InitializeAsync();
    
        Console.WriteLine("Commands Initialized");

        await Task.Delay(-1);
    }
    
    private static ServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<DiscordSocketClient>()
            .AddSingleton<CommandService>()
            .AddSingleton<CommandHandler>()
            .BuildServiceProvider();
    }
    
    private static async Task OnClientLog(LogMessage msg)
    {
        using var botLogger = new BotLogger();
        
        botLogger.WriteLine(msg.Exception.ToString());
    }
}