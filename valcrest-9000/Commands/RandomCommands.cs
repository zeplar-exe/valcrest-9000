﻿using Discord.Commands;
using Discord.Interactions;

namespace Valcrest9000.Commands;

public class RandomCommands : ModuleBase
{
    [Command("random")]
    public async Task Random(int min, int max)
    {
        await ReplyAsync(System.Random.Shared.Next(min, max).ToString());
    }
    
    [Command("dice")]
    public async Task Dice(int n)
    {
        await ReplyAsync(System.Random.Shared.Next(0, n).ToString());
    }

    [Command("8ball")]
    public async Task _8Ball([Remainder] string remainder)
    {
        var responses = new[] { "Yes.", "No.", "Maybe." };
        var index = System.Random.Shared.Next(0, responses.Length);

        await ReplyAsync(responses[index]);
    }
}