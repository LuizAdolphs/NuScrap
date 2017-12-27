using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using AngleSharp;
using AngleSharp.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NuScrap
{
    public class Context
    {
        Account _account;
        HttpClient _client;

        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshBefore { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, Link> Links { get; set; }

        public HttpClient Client
        {
            set
            {
                _client = value;
            }
        }

        public Account Account
        {
            get
            {
                if (_account == null)
                {
                    var result = _client.GetStringAsync(this.Links["account"].Href);

                    _account = JsonConvert.DeserializeObject<AccountResponse>(result.Result, JsonConverters.Settings).Account;
                }

                return _account;
            }
        }

        public static Context Create(string login, string password)
        {
            var config = Configuration
                .Default
                .WithDefaultLoader(setup => setup.IsResourceLoadingEnabled = true);

            var address = "https://app.nubank.com.br/#/login";

            var request = new DocumentRequest(new Url(address));

            var browseContext = BrowsingContext.New(config);

            var response = browseContext.OpenAsync(request, new CancellationToken()).Result;

            var js = response.Scripts.First(x => x.Source != null && x.Source.Contains("config.js"));

            request.Target.Href = browseContext.Active.BaseUri + js.Source;

            var download = new StreamReader(browseContext.Loader.DownloadAsync(request).Task.Result.Content).ReadToEnd();

            var urlDiscovery = download
                .Substring(download.IndexOf("discovery:", StringComparison.InvariantCultureIgnoreCase) + 12
                           , download.IndexOf("/discovery", StringComparison.InvariantCultureIgnoreCase) - download.IndexOf("discovery:"
                           , StringComparison.InvariantCultureIgnoreCase) - 2);

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(urlDiscovery);

            var msg = JsonConvert.DeserializeObject<DiscoveryResponse>(stringTask.Result);

            client = new HttpClient();

            var loginResponse = client.PostAsync(msg.Login, new StringContent("{\"grant_type\":\"password\"," +
                                                                              $"\"login\":\"{login}\"," +
                                                                              $"\"password\":\"{password}\"," +
                                                                              "\"client_id\":\"other.conta\"," +
                                                                              "\"client_secret\":\"yQPeLzoHuJzlMMSAjC-LgNUJdUecx8XO\"}",
                                                                              Encoding.UTF8,
                                                                              "application/json"));



            var context = JsonConvert.DeserializeObject<Context>(loginResponse.Result.Content.ReadAsStringAsync().Result, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            });

            client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {context.AccessToken}");

            context.Client = client;

            return context;

        }

        public class DiscoveryResponse
        {
            public string Login { get; set; }
        }
    }
}
