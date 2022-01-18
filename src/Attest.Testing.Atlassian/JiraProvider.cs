using System;
using System.Net;
using System.Text;
using Attest.Testing.Atlassian.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Attest.Testing.Atlassian
{
    public class JiraProvider
    {
        private const string SprintsFieldId = "customfield_10020";
        private const string IsActive = "active";
        private readonly AtlassianApiHelper _atlassianApiHelper;

        private readonly RestClientFactory _restClientFactory;

        public JiraProvider(
            AtlassianConfigurationProvider atlassianConfigurationProvider,
            AtlassianApiHelper atlassianApiHelper)
        {
            _atlassianApiHelper = atlassianApiHelper;
            _restClientFactory = new RestClientFactory(atlassianConfigurationProvider);
        }

        public bool IsIssueIncludedInTheCurrentSprint(int issueId)
        {
            var issue = GetIssueImpl(issueId);
            var sprints = issue["fields"][SprintsFieldId];
            if (sprints != null)
                foreach (var sprint in sprints)
                    if (sprint["state"].ToString() == IsActive)
                        return true;

            return false;
        }

        public string GetIssueSpecsSection(int issueId)
        {
            var mainContent = GetDescriptionContent(issueId);
            var specsSectionStarted = false;
            var stringBuilder = new StringBuilder();
            //TOD: Very naive approach
            var mainContentItems = mainContent.GetAll();
            foreach (var mainContentItem in mainContentItems)
            {
                var type = mainContentItem["type"].ToString();
                if (type == "paragraph")
                {
                    var innerContent = mainContentItem["content"];
                    if (specsSectionStarted)
                    {
                        foreach (var innerContentItem in innerContent)
                        {
                            var innerType = innerContentItem["type"].ToString();
                            if (innerType == "text")
                            {
                                var innerContentText = innerContentItem["text"].ToString();
                                stringBuilder.Append(innerContentText);
                            }

                            if (innerType == "hardBreak") stringBuilder.AppendLine();
                        }

                        stringBuilder.AppendLine();
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
                    }
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private DescriptionContent GetDescriptionContent(int issueId)
        {
            var issue = GetIssueImpl(issueId);
            var desc = issue["fields"]["description"];
            var mainContent = desc["content"] as JArray;
            return new DescriptionContent(mainContent);
        }

        private JObject GetIssueImpl(int issueId)
        {
            var restClient = _restClientFactory.CreateRestClient();
            var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
            var request = new RestRequest($"rest/api/3/issue/{issueResourceId}", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            var statusCode = response.StatusCode;
            //TODO: Log exception
            if (statusCode != HttpStatusCode.OK)
                throw new Exception($"Failed to connect to Atlassian API, status code is {statusCode}");

            var json = JsonConvert.DeserializeObject<JObject>(response.Content);
            return json;
        }

        public void UpdateIssueDescription(int issueId, JObject descriptionRoot)
        {
            //TODO: For some reason it's required to send issue name as well - should check
            var issue = GetIssueImpl(issueId);
            var restClient = _restClientFactory.CreateRestClient();
            var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
            var request = new RestRequest($"rest/api/3/issue/{issueResourceId}", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var summary = new JArray(new[] { new JObject() })
            {
                [0] =
                {
                    ["set"] = issue["fields"]["summary"]
                }
            };
            var updateBody = new JObject(
                new JProperty("update", new JObject(new JProperty("summary", summary))),
                new JProperty("fields", new JObject(new JProperty("description", descriptionRoot))));

            request.AddJsonBody(JsonConvert.SerializeObject(updateBody));
            var response = restClient.Execute(request);
            var statusCode = response.StatusCode;
            //TODO: Log exception
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.NoContent)
                throw new Exception($"Failed to connect to Atlassian API, status code is {statusCode}");
        }

        public JObject GetIssueRaw(int issueId)
        {
            return GetIssueImpl(issueId);
        }
    }
}