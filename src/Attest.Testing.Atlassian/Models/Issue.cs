using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian.Models
{
    public class Issue
    {
        private readonly JObject _raw;

        private Description _description;

        public Issue(JObject raw)
        {
            _raw = raw;
        }

        public Description Description => _description ??
                                          (_description = new Description(_raw["fields"]["description"] as JObject));
    }
}