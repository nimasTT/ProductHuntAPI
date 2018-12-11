using System;
using System.Collections.Generic;
using ProductHuntAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace ProductHuntAPI
{
    public static class ClientFactory
    {
        public static readonly Uri baseEndpoint = new Uri("https://api.producthunt.com");
        public static readonly int resultsPerPage = 50;

        public static IAsyncHttpClient Create(string clientId, string clientSecret)
        {

            var jsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Error,
            };
            //TODO: Generic + check all classes that implement IRootWithInstance/IRootWithInstances
            jsonSettings.Converters.Add(new RootWithTopicConverter());
            jsonSettings.Converters.Add(new RootWithTopicsConverter());

            var client = new AsyncHttpClient(baseEndpoint,resultsPerPage,jsonSettings);
            IAuthorizationProvider authorizationProvider = new ClientAuthorizationProvider(client, clientId, clientSecret);
            client.AddBearerAuthorization(authorizationProvider.Token);
            return client;
        }

    }
}
