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
                    .WithValue("Output a number between 1 and <max>."),
                new EmbedFieldBuilder()
                    .WithName("cdice <item1, item2, item3, ...>")
                    .WithValue("Create a custom dice and output a random item from the provided list (space-delimited)."),
                new EmbedFieldBuilder()
                    .WithName("8ball <literally-anything>")
                    .WithValue("Yes? No? Maybe."),
                new EmbedFieldBuilder()
                    .WithName("eval <expression>")
                    .WithValue("Output the evaluation of a methematical expression."),
                new EmbedFieldBuilder()
                    .WithName("minesweeper <width> <height> <maxBombs>")
                    .WithValue("Creates a minesweeper game of <width>x<height> size with <maxBombs> bombs at most."),
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