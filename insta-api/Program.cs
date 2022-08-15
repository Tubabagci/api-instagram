using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace insta_api
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();

            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
                Console.WriteLine(repo.Description);
                Console.WriteLine(repo.GitHubHomeUrl);
                Console.WriteLine(repo.Homepage);
                Console.WriteLine(repo.Watchers);
                Console.WriteLine(repo.LastPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {
            string VERSION = "v11.0";
            string USER_ID = "17841454972667293";
            string TOKEN_60 = "IGQVJWaC1abVd3R3ViYVVpdUhZAUVF5aUx2T19iR00tQmxtcmdRM3Y2QVBFczktcURLWm8wRUZAWQXN5V3dVNVEwbE0xdlRjYTBXMmRzTnYwOWZAkemhKYVhyT1RmUmZAnTjRkUkFZAel93";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://graph.instagram.com/+"+VERSION+"/"+USER_ID+"/media?access_token="+TOKEN_60+"&fields=permalink");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            return repositories;
        }
    }
}
