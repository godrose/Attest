using System.Collections.Generic;
using Newtonsoft.Json;

namespace Attest.Testing.Atlassian.Models
{
    internal class Attrs
    {
        [JsonProperty("isNumberColumnEnabled")]
        public bool IsNumberColumnEnabled { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }
    }

    internal class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }

    internal class JiraTable
    {
        [JsonProperty("type")]
        public string Type = "table";

        [JsonProperty("attrs")]
        public Attrs Attrs { get; set; }

        [JsonProperty("content")]
        public List<JiraTableRow> table { get; set; } = new List<JiraTableRow>();
    }

    internal class CellContent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public List<Content> text { get; set; } = new List<Content>();

    }

    internal class JiraCell
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public List<CellContent> content { get; set; } = new List<CellContent>();

    }

    internal class JiraTableRow
    {
        [JsonProperty("type")]
        public string Type = "tableRow";

        [JsonProperty("content")]
        public List<JiraCell> content { get; set; } = new List<JiraCell>();

    }

    internal class Body
    {
        [JsonProperty("version")]
        public int Version = 1;

        [JsonProperty("type")]
        public string Type = "doc";

        [JsonProperty("content")]
        public List<JiraTable> Content { get; set; } = new List<JiraTable>();
    }

    internal class Root
    {
        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    internal class Comment
    {
        [JsonProperty("type")]
        public string type = "paragraph";
        [JsonProperty("content")]
        public List<Content> Text { get; set; } = new List<Content>();
    }
}