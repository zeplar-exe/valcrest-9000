using Discord.Commands;
using Discord.Interactions;

namespace Valcrest9000.Commands;

public class PingCommands : ModuleBase
{
    [Command("ping-random")]
    [RequireRole(853369121000521780)]
    public async Task PingRandom()
    {
        var users = (await Context.Guild.GetUsersAsync()).ToArray();
        var selected = users[Random.Shared.Next(0, users.Length)];

        if (selected == null)
        {
            await ReplyAsync("This shouldn't be possible... The user... doesn't exist?");
            
            return;
        }

        await ReplyAsync(selected.Mention);
        // Ping
    }

    [Command("ping-random-in")]
    [RequireRole(853369121000521780)]
    public async Task PingRandom(ulong roleId)
    {
        var role = Context.Guild.GetRole(roleId);

        if (role == null)
        {
            await ReplyAsync("A role by that ID doesn't exist.");
            
            return;
        }
        
        var users = (await Context.Guild.GetUsersAsync())
            .Where(u => u.RoleIds.Contains(roleId))
            .ToArray();
        var selected = users[Random.Shared.Next(0, users.Length)];

        await ReplyAsync(selected.Mention);
    }
}