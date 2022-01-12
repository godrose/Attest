using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Attest.Testing.Atlassian
{
    public class RestClientFactory
    {
        private readonly AtlassianConfigurationProvider _atlassianConfigurationProvider;

        //TODO: Put into config
        private readonly string User;
        private readonly string Secret;

        public RestClientFactory(AtlassianConfigurationProvider atlassianConfigurationProvider)
        {
            _atlassianConfigurationProvider = atlassianConfigurationProvider;
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
            var baseUrl = _atlassianConfigurationProvider.BaseUrl;
            var restClient = new RestClient(baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(User, Secret)
            };
            return restClient;
        }
    }
}
