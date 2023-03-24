using System.Data;
using Discord.Commands;

namespace Valcrest9000.Commands;

public class MathCommands : ModuleBase
{
    [Command("eval")]
    public async Task Evaluate([Remainder] string input)
    {
        var table = new DataTable();
        var value = table.Compute(input, null);

        if (value == DBNull.Value)
        {
            await ReplyAsync("Your equation is invalid. Try again.");
        }
        else
        {
            await ReplyAsync(value.ToString());
        }
    }
}