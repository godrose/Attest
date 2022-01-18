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
        private readonly DescriptionContentFactory _descriptionContentFactory;
        private readonly RestClientFactory _restClientFactory;

        public JiraProvider(
            AtlassianConfigurationProvider atlassianConfigurationProvider,
            AtlassianApiHelper atlassianApiHelper,
            DescriptionContentFactory descriptionContentFactory)
        {
            _atlassianApiHelper = atlassianApiHelper;
            _descriptionContentFactory = descriptionContentFactory;
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
            var stringBuilder = new StringBuilder();
            var specContentItems = mainContent.GetSpecs();
            foreach (var specContentItem in specContentItems)
            {
                var type = specContentItem["type"].ToString();
                if (type == "paragraph")
                {
                    var innerContent = specContentItem["content"];
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
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private DescriptionContent GetDescriptionContent(int issueId)
        {
            var issue = GetIssueImpl(issueId);
            return _descriptionContentFactory.Create(issue);
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
            var restClient = _restClientFactory.CreateRestClient();
            var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
            var request = new RestRequest($"rest/api/3/issue/{issueResourceId}", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var updateBody = new JObject(
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