using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Valcrest9000.Commands;

public class CommandHandler
{
    private CommandService Commands { get; }
    private DiscordSocketClient Client { get; }
    private IServiceProvider Services { get; }

    public CommandHandler(IServiceProvider services)
    {
        Commands = services.GetRequiredService<CommandService>();
        Client = services.GetRequiredService<DiscordSocketClient>();
        Services = services;
        
        Commands.CommandExecuted += CommandExecutedAsync;
        Client.MessageReceived += MessageReceivedAsync;
    }

    public async Task InitializeAsync()
    {
        await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Services);
    }
    
    public async Task MessageReceivedAsync(SocketMessage rawMessage)
    {
        // IF rawMessage IS NOT a SocketUserMessage WHERE SocketUserMessage.Source IS MessageSource.User, RETURN
        if (rawMessage is not SocketUserMessage { Source: MessageSource.User } message)
            return;

        if (rawMessage.ToString().Contains("4. Carps aren't bottoms"))
        {
            await rawMessage.Channel.SendMessageAsync("5. Carps ARE bottoms");

            return;
        }

        var argIndex = 0;
        
        if (!message.HasMentionPrefix(Client.CurrentUser, ref argIndex))
        {
            using var config = new ConfigInterface();

            var channel = rawMessage.Channel as SocketGuildChannel;
            var guild = channel?.Guild;
            
            if (guild == null)
                return;
            
            if (!message.HasStringPrefix(config.Prefix(), ref argIndex))
                return;
        }

        var context = new SocketCommandContext(Client, message);
        
        await Commands.ExecuteAsync(context, argIndex, Services); 
    }

    public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
    {
        if (!command.IsSpecified)
        {
            return;
        }
        
        if (result.IsSuccess)
        {
            return;
        }
        
        await context.Channel.SendMessageAsync($"Sorry, something went wrong!{Environment.NewLine}{result.ErrorReason}");
    }
}