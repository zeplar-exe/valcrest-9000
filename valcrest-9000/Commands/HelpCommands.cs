using Discord;
using Discord.Commands;

namespace Valcrest9000.Commands;

public class HelpCommands : ModuleBase
{
    [Command("help")]
    public async Task Help()
    {
        var embed = new EmbedBuilder()
            .WithTitle("Valcrest 9000 Help")
            .WithFields(new[]
            {
                new EmbedFieldBuilder()
                    .WithName("help")
                    .WithValue("Run this command."),
                new EmbedFieldBuilder()
                    .WithName("random <min> <max>")
                    .WithValue("Output a number between <min> and <max>."),
                new EmbedFieldBuilder()
                    .WithName("dice <max>")
                    .WithValue("Output a number between 0 and <max>."),
                new EmbedFieldBuilder()
                    .WithName("8ball <literally-anything>")
                    .WithValue("Yes? No? Maybe."),
                new EmbedFieldBuilder()
                    .WithName("eval <expression>")
                    .WithValue("Output the evaluation of a methematical expression."),
                new EmbedFieldBuilder()
                    .WithName("ping-random")
                    .WithValue("Ping a random user."),
                new EmbedFieldBuilder()
                    .WithName("ping-random-in <role-id>")
                    .WithValue("Ping a random user in the specified role by ID."),
                new EmbedFieldBuilder()
                    .WithName("trello <card-id>")
                    .WithValue("Output the description of the specified card on the Arcane Odyssey Trello."),
                new EmbedFieldBuilder()
                    .WithName("trello-short <card-id> [truncateLength]")
                    .WithValue("Output the truncated description of the specified card on the Arcane Odyssey Trello. Default truncateLength is 1000 characters."),
                new EmbedFieldBuilder()
                    .WithName("trello-update")
                    .WithValue("NOT IMPLEMENTED."),
                new EmbedFieldBuilder()
                    .WithName("trello-auto")
                    .WithValue("NOT IMPLEMENTED."),
            });

        await ReplyAsync(embed: embed.Build());
    }
}