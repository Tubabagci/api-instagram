using System;
using System.Globalization;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace insta_api
{
    public class Repository
    {

        public class fields
        {
            public string permalink { get; set; }
            public string id { get; set; }
        }


        public class Cursors
        {
            public string before { get; set; }
            public string after { get; set; }
        }

        [JsonPropertyName("data")]
        public fields[] data { get; set; }

        [JsonPropertyName("paging")]
        public Dictionary<string, Cursors>? paging { get; set; }


    }

}