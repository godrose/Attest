using System.IO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Attest.Testing.Atlassian
{
    public class RestClientFactory
    {
        private readonly IConfiguration _configuration;

        //TODO: Put into config
        private readonly string User;
        private readonly string Secret;

        public RestClientFactory(IConfiguration configuration)
        {
            _configuration = configuration;
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

        public RestClient CreateRestClient()
        {
            var baseUrl = _configuration.GetSection("Atlassian").GetSection("BaseUrl").Value;
            var restClient = new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(User, Secret)
            };
            return restClient;
        }
    }
}
