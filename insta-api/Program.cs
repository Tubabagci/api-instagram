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

        



        public class instaModel
                {
            
                            public Dictionary<string, cursors>? paging { get; set; }
                            public fields[] data { get; set; }
                        }

                        public class fields
                        {
                            public string permalink { get; set; }
                            public string id { get; set; }
                        }


                        public class cursors
                        {
                            public string before { get; set; }
                            public string after { get; set; }
                        }

        public static async Task Main()
        {


                            string jsonString =
                                            @"{
  
                                            ""data"": [
                                                    {
                                                            ""permalink"": ""https://www.instagram.com/p/ChR_0BLMLLZ/"",
                                                             ""id"": ""17973110518679928""
                                                    },
                                                    {
                                                            ""permalink"": ""https://www.instagram.com/p/ChR3lWssd-k/"",
                                                             ""id"": ""17942418470216798""
                                                    }
                                                ],
                                                ""paging"": {
                                                            ""cursors"": {
                                                                ""before"": ""QVFIUmZAkaHE0T0J1NmJNbk5ZANW92MmFRUEd0cGN5WW4yMXFTSDJZAWDB0TkRTMlIyZAEpaMWE4aGQyNFdyaE9nODd3ZAlhZANDhDeld1SE4tdnFXbGNEN21KaGdB"",
                                                        ""after"": ""QVFIUmtlV0FQUm50ZAVVuUzVLQXEzMTR2MURPM0xpNGVMaEdDMllvbmFka2tvUFoyY2Q5YjFXdHZADc0YyUzFLZAzJJVno2bHh6ekhvT0xpaDIwc1lhaF9kTzl3""
                                                            }
                                                        }

                                                    }
                                            ";

            instaModel? instaModel1 = JsonSerializer.Deserialize<instaModel>(jsonString);

            foreach (var item in instaModel1?.data)
            {
                Console.WriteLine($"Date: {item.permalink}");
            }


            /* foreach (KeyValuePair<string, cursors> kvp in instaModel?.paging)
             {
                 Console.WriteLine(" before degeri = {0}, \n  after degeri = {1}", kvp.Value.before, kvp.Value.after);
             }*/



            

            string VERSION = "v11.0";
            string USER_ID = "17841454972667293";
            string TOKEN_60 = "ÖÇŞ-IGQVJYdm9TOXMwc2ViZAVgxbzRHa2FrYmdKYnJiUG9TcGg2a3Ywb3BiWFhTNTR0ZA3lXdW54WHBEZAjU3MlE4WmkyTXlIbl9EeHNtUnZAEOTdfa2ZAmdDBzaU03NjdSTEl3RWd0eW5Jblhn";
            string url = "https://graph.instagram.com/+" + VERSION + "/" + USER_ID + "/media?access_token=" + TOKEN_60 + "&fields=permalink";




            var repositories = await ProcessRepositories(url);

            foreach (var repo in repositories.data)
            {
                Console.WriteLine(repo.permalink);
               
                Console.WriteLine();
            }


        }



        private static async Task<instaModel> ProcessRepositories(string url)
        {


            HttpClient client = new HttpClient();

            var streamTask = client.GetStreamAsync(url);

            var repositories = await JsonSerializer.DeserializeAsync<instaModel>(await streamTask);

            return repositories;
        }




    }

}
    
