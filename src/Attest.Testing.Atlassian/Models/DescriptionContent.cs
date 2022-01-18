using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Attest.Testing.Atlassian.Models
{
    public class DescriptionContent
    {
        private readonly AtlassianConfigurationProvider _atlassianConfigurationProvider;
        private readonly List<JToken> _beforeSpecs = new List<JToken>();
        private List<JToken> _specs = new List<JToken>();

        public DescriptionContent(
            AtlassianConfigurationProvider atlassianConfigurationProvider,
            JArray source)
        {
            _atlassianConfigurationProvider = atlassianConfigurationProvider;
            AnalyzeRaw(source);
        }

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
                            if (innerContentText == _atlassianConfigurationProvider.SpecsToken)
                            {
                                specsSectionStarted = true;
                                break;
                            }
                        }

                        if (!specsSectionStarted) _beforeSpecs.Add(mainContentItem);
                    }
                }
            }
        }

        public IEnumerable<JToken> GetAll()
        {
            return _beforeSpecs
                .Concat(new JToken[] { Paragraph.TextToJiraParagraph(_atlassianConfigurationProvider.SpecsToken) })
                .Concat(_specs).ToList();
        }

        public IEnumerable<JToken> GetSpecs()
        {
            return _specs.ToList();
        }
    }
}