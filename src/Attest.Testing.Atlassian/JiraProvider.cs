using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Attest.Testing.Atlassian
{
    public class JiraProvider
    {
        private readonly AtlassianApiHelper _atlassianApiHelper;
        private const string SprintsFieldId = "customfield_10020";
        private const string IsActive = "active";

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
            var restClient = _restClientFactory.CreateRestClient();
            var issueResourceId = _atlassianApiHelper.BuildIssueResourceId(issueId);
            var request = new RestRequest($"rest/api/3/issue/{issueResourceId}", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request);
            var statusCode = response.StatusCode;
            //TODO: Log exception
            if (statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to connect to Atlassian API, status code is {statusCode}");
            }

            var json = JsonConvert.DeserializeObject<JObject>(response.Content);
            var sprints = json["fields"][SprintsFieldId];
            if (sprints != null)
            {
                foreach (var sprint in sprints)
                {
                    if (sprint["state"].ToString() == IsActive)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}