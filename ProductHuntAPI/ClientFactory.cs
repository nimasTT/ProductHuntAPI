using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI
{
    public static class ClientFactory
    {
        public static readonly Uri baseEndpoint = new Uri("https://api.producthunt.com");
        public static readonly int resultsPerPage = 50;

        public static IAsyncHttpClient Create(string clientId, string clientSecret)
        {
            var client = new AsyncHttpClient(baseEndpoint,resultsPerPage);
            IAuthorizationProvider authorizationProvider = new ClientAuthorizationProvider(client, clientId, clientSecret);
            client.AddBearerAuthorization(authorizationProvider.Token);
            return client;
        }

    }
}
