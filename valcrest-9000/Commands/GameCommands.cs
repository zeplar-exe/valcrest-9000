using System.Text;

using Discord.Commands;

namespace Valcrest9000.Commands;

public class GameCommands : ModuleBase
{
    [Command("minesweeper")]
    public async Task MineSweeper(int width, int height, int maxBombs)
    {
        const int MaxSideLength = 24;

        if (width > MaxSideLength || height > MaxSideLength)
        {
            await ReplyAsync($"No. Minesweeper has a maximum size of {MaxSideLength}x{MaxSideLength}.");
            
            return;
        }

        var bombCount = 0;
        

        for (var x = 0; x < width; x++)
        {
            var line = new StringBuilder();
            
            for (var y = 0; y < height; y++)
            {
                if (bombCount <= maxBombs && Random.Shared.NextDouble() > 0.80)
                {
                    line.Append("||:boom:||");
                    bombCount++;
                }
                else
                {
                    line.Append("||      ||");
                }
            }
            
            await ReplyAsync(line.ToString());
        }
    }
}