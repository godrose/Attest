using System;
using System.IO;
using System.Net;
using Attest.Testing.Atlassian.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Attest.Testing.Atlassian
{
    public class WorkflowHelper
    {
        private const string JiraUrl = "https://godrose.atlassian.net/";
        private readonly string User;
        private readonly string Secret;
        private const string SprintsFieldId = "customfield_10020";
        private const string IsActive = "active";

        public WorkflowHelper()
        {
            //TODO: Move to Hook
            var file = "secret.json";
            if (File.Exists(file))
            {
                //TODO: Use env vars
                var contents = File.ReadAllText(file);
                var data = JsonConvert.DeserializeObject<JObject>(contents);
                User = data["user"].ToString();
                Secret = data["secret"].ToString();
            }
        }

        public bool IsCurrentSprint(int ticket)
        {
            var restClient = CreateRestClient();
            var request = new RestRequest($"rest/api/3/issue/BDD-{ticket}", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = restClient.Execute(request); 
            var statusCode = response.StatusCode;
            //TODO: Log exception
            if (statusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Failed to connect to JIRA API, status code is {statusCode}");
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

        private RestClient CreateRestClient()
        {
            var restClient = new RestClient(JiraUrl);
            restClient.Authenticator = new HttpBasicAuthenticator(User, Secret);
            return restClient;
        }

        public int SendContentGetRequest(int pageId)
        {
            var client = CreateRestClient();
            var request = new RestRequest($"wiki/rest/api/content/{pageId}/", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            ConfluenceContentResponseModel model = JsonConvert.DeserializeObject<ConfluenceContentResponseModel>(response.Content);
            var newVersion = model.Version.Number + 1;
            return newVersion;
        }

        public void SendPostRequest(int pageId, object body)
        {
            RestClient client = CreateRestClient();
            RestRequest request = new RestRequest($"wiki/rest/api/content/{pageId}/", Method.PUT);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("expand", "body.storage", ParameterType.QueryString);

            string bodyAsString = JsonConvert.SerializeObject(body);
            request.AddJsonBody(bodyAsString);

            var response = client.Execute(request);

            int statusCode = (int)response.StatusCode;
            if (statusCode != 200)
                throw new Exception("request failed, status code - " + statusCode);
        }
    }
}

