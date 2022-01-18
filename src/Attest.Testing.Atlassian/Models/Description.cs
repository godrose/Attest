using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian.Models
{
    public class Description
    {
        private readonly JObject _raw;
        private const string ContentFieldName = "content";

        public Description(JObject raw)
        {
            _raw = raw;
        }

        public JArray Content
        {
            get => _raw[ContentFieldName] as JArray;
            set => _raw[ContentFieldName] = value;
        }

        public JObject GetRaw()
        {
            return _raw;
        }
    }
}