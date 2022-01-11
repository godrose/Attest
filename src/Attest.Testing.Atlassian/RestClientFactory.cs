using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace Attest.Testing.Atlassian
{
    public class RestClientFactory
    {
        //TODO: Put into config
        private const string JiraUrl = "https://godrose.atlassian.net/";
        private readonly string User;
        private readonly string Secret;

        public RestClientFactory()
        {
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
            var restClient = new RestClient(JiraUrl)
            {
                Authenticator = new HttpBasicAuthenticator(User, Secret)
            };
            return restClient;
        }
    }
}
