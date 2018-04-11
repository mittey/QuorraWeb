using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using QuorraWeb.Interfaces;

namespace QuorraWeb.Services
{
    public class MusicService : IMusicService
    {
        private readonly IConfiguration _configuration;

        public MusicService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task HandleQueryAsync(string query)
        {
            var webHookUrl = _configuration.GetValue<string>("PlayerWebhookUrl");

            var playRequest = WebRequest.Create("http://localhost:3000/api/music/play");
            playRequest.ContentType = "application/json";
            playRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(await playRequest.GetRequestStreamAsync()))
            {
                var json = "{\"query\": \"" + query + "\"}";

                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var playResponse = playRequest.GetResponse();
            using (var streamReader = new StreamReader(playResponse.GetResponseStream() ?? throw new InvalidOperationException()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}