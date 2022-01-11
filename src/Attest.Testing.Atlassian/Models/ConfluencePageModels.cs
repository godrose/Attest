using Newtonsoft.Json;

namespace Attest.Testing.Atlassian.Models
{
    public class CVersion
    {
        [JsonProperty("number")]
        public int Number { get; set; }
    }

    public class Storage
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("representation")]
        public string Representation { get; set; }
    }

    public class CBody
    {
        [JsonProperty("storage")]
        public Storage Storage { get; set; }
    }

    public class CRoot
    {
        [JsonProperty("version")]
        public CVersion version { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public CBody Body { get; set; }
    }
}
