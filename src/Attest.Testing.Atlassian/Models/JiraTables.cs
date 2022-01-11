using System.Collections.Generic;
using Newtonsoft.Json;

namespace Attest.Testing.Atlassian.Models
{
    public class Attrs
    {
        [JsonProperty("isNumberColumnEnabled")]
        public bool IsNumberColumnEnabled { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }
    }


    public class Content
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

    }

    public class JiraTable
    {
        [JsonProperty("type")]
        public string Type = "table";

        [JsonProperty("attrs")]
        public Attrs Attrs { get; set; }

        [JsonProperty("content")]
        public List<JiraTableRow> table { get; set; } = new List<JiraTableRow>();
    }

    public class CellContent
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public List<Content> text { get; set; } = new List<Content>();

    }

    public class JiraCell
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public List<CellContent> content { get; set; } = new List<CellContent>();

    }

    public class JiraTableRow
    {
        [JsonProperty("type")]
        public string Type = "tableRow";

        [JsonProperty("content")]
        public List<JiraCell> content { get; set; } = new List<JiraCell>();

    }

    public class Body
    {
        [JsonProperty("version")]
        public int Version = 1;

        [JsonProperty("type")]
        public string Type = "doc";

        [JsonProperty("content")]
        public List<JiraTable> Content { get; set; } = new List<JiraTable>();
    }

    public class Root
    {
        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public class Comment
    {
        [JsonProperty("type")]
        public string type = "paragraph";
        [JsonProperty("content")]
        public List<Content> Text { get; set; } = new List<Content>();
    }
}