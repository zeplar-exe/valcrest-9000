using System.Text;

using Discord.Commands;

namespace Valcrest9000.Commands;

public class GameCommands : ModuleBase
{
    [Command("minesweeper")]
    public async Task MineSweeper(int width, int height, int maxBombs)
    {
        const int MaxSideLength = 20;

        if (width > MaxSideLength || height > MaxSideLength)
        {
            await ReplyAsync($"No. Minesweeper has a maximum size of {MaxSideLength}x{MaxSideLength}.");
            
            return;
        }

        var bombCount = 0;
        var message = new StringBuilder();

        for (var x = 0; x < width; x++)
        {
            for (var y = 0; y < height; y++)
            {
                if (bombCount <= maxBombs && Random.Shared.NextDouble() > 0.5)
                {
                    message.Append("||:boom:||");
                    bombCount++;
                }
                else
                {
                    message.Append("|| ||");
                }
            }
        }

        await ReplyAsync(message.ToString());
    }
}