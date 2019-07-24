﻿using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace MajorInteractiveBot.Modules
{
    public class GeneralCommands : ModuleBase
    {
        private readonly DiscordSocketClient _discordClient;

        public GeneralCommands(DiscordSocketClient discordClient)
        {
            _discordClient = discordClient;
        }

        [Command("ping")]
        [Summary("Ping MODiX to determine connectivity and latency")]
        public Task Ping()
            => ReplyAsync($"Pong! ({_discordClient.Latency} ms)");
    }
}
