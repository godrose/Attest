using System;
using System.Net;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Attest.Testing.Atlassian
{
    public class JiraProvider
    {
        private readonly IConfiguration _configuration;
        private const string SprintsFieldId = "customfield_10020";
        private const string IsActive = "active";

        private readonly RestClientFactory _restClientFactory;

        public JiraProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _restClientFactory = new RestClientFactory(configuration);
        }

        public bool IsIssueIncludedInTheCurrentSprint(int issueId)
        {
            var restClient = _restClientFactory.CreateRestClient();
            var issuePrefix = _configuration.GetSection("Atlassian").GetSection("Jira").GetSection("IssuePrefix").Value;
            var request = new RestRequest($"rest/api/3/issue/{issuePrefix}-{issueId}", Method.GET);
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