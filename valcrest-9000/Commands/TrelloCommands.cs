using Discord;
using Discord.Commands;
using Discord.Interactions;

namespace Valcrest9000.Commands;

public class TrelloCommands : ModuleBase
{
    [Command("trello")]
    [RequireRole(853370034100371467)] 
    public async Task Card(string id)
    {

        var requester = new TrelloRequester();

        var cardJson = await requester.RequestCardJsonAsync(id);

        if (cardJson == null)
        {
            await ReplyAsync("A card by this ID does not exist.");
            
            return;
        }

        var name = cardJson["name"]?.ToString() ?? "null";
        var desc = cardJson["desc"]?.ToString() ?? "null";
        
        foreach (var embed in CreateEmbeds(name, desc))
        {
            await ReplyAsync(embed: embed.Build());
        }
    }
    
    [Command("trello-short")]
    [RequireRole(853370034100371467)]
    public async Task CardShort(string id, int trim = 1000)
    {


        var requester = new TrelloRequester();

        var cardJson = await requester.RequestCardJsonAsync(id);

        if (cardJson == null)
        {
            await ReplyAsync("A card by this ID does not exist.");
            
            return;
        }
        
        var name = cardJson["name"]?.ToString() ?? "null";
        var desc = cardJson["desc"]?.ToString() ?? "null";

        var trimmedDesc = desc.Substring(0, Math.Min(trim, desc.Length));

        var embeds = CreateEmbeds(name, trimmedDesc).ToArray();
        
        foreach (var embed in embeds)
        {
            if (embed == embeds.Last())
            {
                var field = new EmbedFieldBuilder()
                    .WithName("Full Card")
                    .WithValue($"https://trello.com/c/{id}")
                    .WithIsInline(true);
                
                if (desc != trimmedDesc)
                    embed.Description += "...";

                embed.AddField(field);
            }

            await ReplyAsync(embed: embed.Build());
        }
    }

    private async Task<bool> AssertValidChannel()
    {
        var channelId = Context.Channel.Id;

        var validChannels = new[] { 
            864484992544538624ul, 
            864489825461600297ul,
            853368269087178785ul,
            996502543062548531ul
        }.ToHashSet();

        if (!validChannels.Contains(channelId)) // updates, bots-and-music, staff-general, coders-den
        {
            await ReplyAsync("This command is limited to updates, bots-and-music, and certain staff channels.");
            
            return false;
        }

        return true;
    }
    
    [Command("trello-update")]
    public async Task Update()
    {
        
    }
    
    [Command("trello-auto")]
    public async Task Update(bool state)
    {
        
    }

    private IEnumerable<EmbedBuilder> CreateEmbeds(string title, string text)
    {
        var parts = SplitInParts(text, 2000);

        foreach (var part in parts)
        {
            var embed = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(part.ToString());

            yield return embed;
        }
    }
    
    public static IEnumerable<ReadOnlyMemory<char>> SplitInParts(string s, int partLength)
    {
        if (s == null)
            throw new ArgumentNullException(nameof(s));
        if (partLength <= 0)
            throw new ArgumentException("Part length has to be positive.", nameof(partLength));

        for (var i = 0; i < s.Length; i += partLength)
            yield return s.AsMemory().Slice(i, Math.Min(partLength, s.Length - i));
    }
}
