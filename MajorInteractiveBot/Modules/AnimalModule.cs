﻿using Discord;
using Discord.Commands;
using MajorInteractiveBot.Attributes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace MajorInteractiveBot.Modules
{
    [Name("Animal")]
    [Summary("A collection of commands for displaying animals of the specified type.")]
    [Module]
    public class AnimalModule : ModuleBase
    {
        private readonly ILogger<AnimalModule> Log;
        private readonly IServiceProvider _services;

        public AnimalModule(IServiceProvider services)
        {
            _services = services;
            Log = services.GetRequiredService<ILogger<AnimalModule>>();
        }

        private const string FindBird = "https://random.birb.pw/tweet/";
        private const string BirdPicture = "https://random.birb.pw/img/{0}";

        private const string CatPicture = "https://api.thecatapi.com/v1/images/search";

        [Command("bird")]
        [Alias("birb")]
        [Summary("Shows a random bird.")]
        [RequireCommandChannel]
        public async Task ShowBird()
        {
            string location = await GetAsync(FindBird);

            await ShowPicture("bird", string.Format(BirdPicture, location));
        }

        [Command("cat")]
        [Summary("Show a random cat")]
        [RequireCommandChannel]
        public async Task ShowCat()
        {
            string location = await GetJsonAsync(CatPicture, "url");
            await ShowPicture("cat", location);
        }

        private async Task<string> GetJsonAsync(string uri, string key)
        {
            string json = await GetAsync(uri);

            var jArray = JArray.Parse(json);
            var jToken = jArray.First;

            return jToken.Value<string>(key);            
        }

        private async Task ShowPicture(string type, string uri)
        {
            var message = await ReplyAsync($"Searching for a {type}...");
            try
            {
                var imageEmbed = EmbedFromImage(uri);

                await message.ModifyAsync(msg =>
                {
                    msg.Content = "Found one!";
                    msg.Embed = imageEmbed.Build();
                });
            }
            catch (Exception ex)
            {
                Log.LogCritical(ex, "Image lookup failed.");
            }
        }

        private async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private EmbedBuilder EmbedFromImage(string imageUrl)
        {
            return new EmbedBuilder().WithImageUrl(imageUrl);
        }
    }
}
