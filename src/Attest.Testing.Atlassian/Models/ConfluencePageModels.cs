using Newtonsoft.Json;

namespace Attest.Testing.Atlassian.Models
{
    internal class CVersion
    {
        [JsonProperty("number")]
        public int Number { get; set; }
    }

    internal class Storage
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("representation")]
        public string Representation { get; set; }
    }

    internal class CBody
    {
        [JsonProperty("storage")]
        public Storage Storage { get; set; }
    }

    internal class CRoot
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
