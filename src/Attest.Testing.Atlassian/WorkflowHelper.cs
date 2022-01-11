using System;
using System.Net;
using Attest.Testing.Atlassian.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Attest.Testing.Atlassian
{
    public class WorkflowHelper
    {
        private const string SprintsFieldId = "customfield_10020";
        private const string IsActive = "active";
        private readonly RestClientFactory _restClientFactory;

        public WorkflowHelper()
        {
            _restClientFactory = new RestClientFactory();
        }

        public bool IsCurrentSprint(int ticket)
        {
            var restClient = _restClientFactory.CreateRestClient();
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

        public int SendContentGetRequest(int pageId)
        {
            var client = _restClientFactory.CreateRestClient();
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
            RestClient client = _restClientFactory.CreateRestClient();
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

