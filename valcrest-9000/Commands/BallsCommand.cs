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
    
    [Command("fishfucker")]
    [RequireRole(853369121000521780)]
    public async Task Fishfucker()
    {
        await ReplyAsync(
            "Zarachy Salore is a fishfucker: https://docs.google.com/document/d/1-RSf8WQxxJpmix6DX2oVIA0wN_UN75NY9K_GsdC4Dkg");
    }

    [Command("boobs")] 
    public async Task Boobs()
    {
        await ReplyAsync(
            "uhhhh uh hh h h   h h " +
"huge anime hadonkadonk bazonka zoongalar tiddies ");
    }
    
    [Command("java")]
    [RequireRole(853369121000521780)]
    public async Task JAVA()
    {
        await ReplyAsync(
            "I think we can all agree that Java fucking sucks. C# is so much better.");
    }
}
