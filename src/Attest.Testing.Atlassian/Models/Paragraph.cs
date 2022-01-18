using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian.Models
{
    internal class Paragraph
    {
        internal static JObject TextToJiraParagraph(string line)
        {
            return new JObject(

                new JProperty("type", "paragraph"),
                new JProperty("content", new JArray(new[] { new JObject() })
                {
                    [0] = new JObject(new JProperty("type", "text"), new JProperty("text", line))
                }));
        }
    }
}
