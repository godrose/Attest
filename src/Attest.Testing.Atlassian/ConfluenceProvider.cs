using System;
using Attest.Testing.Atlassian.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Attest.Testing.Atlassian
{
    public sealed class ConfluenceProvider
    {
        private readonly RestClientFactory _restClientFactory;

        public ConfluenceProvider(IConfiguration configuration)
        {
            _restClientFactory = new RestClientFactory(configuration);
        }

        public int GetNewPageVersion(int pageId)
        {
            var client = _restClientFactory.CreateRestClient();
            var request = new RestRequest($"wiki/rest/api/content/{pageId}/", Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            var model = JsonConvert.DeserializeObject<ConfluenceContentResponseModel>(response.Content);
            var newVersion = model.Version.Number + 1;
            return newVersion;
        }

        public void UpdatePage(int pageId, object body)
        {
            var client = _restClientFactory.CreateRestClient();
            var request = new RestRequest($"wiki/rest/api/content/{pageId}/", Method.PUT);
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

