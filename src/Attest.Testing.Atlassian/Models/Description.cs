using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian.Models
{
    public class Description
    {
        private List<JToken> _beforeSpecs = new List<JToken>();
        private List<JToken> _specs = new List<JToken>();

        public Description(JArray raw)
        {
            AnalyzeRaw(raw);
        }

        public List<JToken> BeforeSpecs => _beforeSpecs;

        public void UpdateSpecs(List<JToken> specs)
        {
            _specs = specs;
        }

        private void AnalyzeRaw(JArray raw)
        {
            var specsSectionStarted = false;
            //TODO: Very naive approach
            foreach (var mainContentItem in raw)
            {
                var type = mainContentItem["type"].ToString();
                if (type == "paragraph")
                {
                    var innerContent = mainContentItem["content"];
                    if (specsSectionStarted)
                    {
                        _specs.Add(mainContentItem);
                    }
                    else
                    {
                        foreach (var innerContentItem in innerContent)
                        {
                            var innerContentText = innerContentItem["text"].ToString();
                            if (innerContentText == "Specs:")
                            {
                                specsSectionStarted = true;
                                break;
                            }
                        }

                        if (!specsSectionStarted)
                        {
                            _beforeSpecs.Add(mainContentItem);
                        }
                    }
                }
            }
        }
    }
}
