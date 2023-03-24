using Discord.Commands;
using Discord.Interactions;

namespace Valcrest9000.Commands;

public class BallsCommand : ModuleBase
{
    [Command("balls")]
    [RequireRole(853369121000521780)]
    public async Task Balls()
    {
        await ReplyAsync(
            "Zarachy Salore's balls are twice the size of Ray's. All hail the wielder of massive balls!");
    }
}