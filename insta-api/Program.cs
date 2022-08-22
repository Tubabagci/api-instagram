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

        public class instaModel
        {
            public fields[] data { get; set; }
        }

        public class fields
        {
            public string permalink { get; set; }
            public string id { get; set; }
        }

        public static async Task Main()
        {

            string VERSION = "v11.0";
            string USER_ID = "***17841454972667293";
            string TOKEN_60 = "***IGQVJYYkFheHRBbUhmbnRHRDljeUtydi1fS3ZA1MWJ3UktYbWlxaHYtbGkwNkVSdzdXNDdfNVFLMjZAHNDBwT2pmenVuWGxoSnBIbUVEeVB2S2FURlVuaTdMWDNRZA2dNVFVXaEFSWlFR";
            string url = "https://graph.instagram.com/" + VERSION + "/" + USER_ID + "/media?access_token=" + TOKEN_60 + "&fields=permalink";


            var repositories2 = await instaPostUrl(url);
            foreach (var repo in repositories2.data)
            {

                Console.WriteLine(repo.permalink);

            }

        }

        private static async Task<instaModel> instaPostUrl(string url)
        {

            var streamTask = client.GetStreamAsync(url);

            var repositories = await JsonSerializer.DeserializeAsync<instaModel>(await streamTask);

            return repositories;
        }




    }

}

