using System;
using System.Collections.Generic;
using ProductHuntAPI.Models;
using Newtonsoft.Json;
using System.Text;
using System.Security.Authentication;

namespace ProductHuntAPI
{
    internal static class ClientFactory
    {
        private  static readonly Uri baseEndpoint = new Uri("https://api.producthunt.com");
        internal static readonly int resultsPerPage = 50;

        internal static IAsyncHttpClient Create(string clientId, string clientSecret)
        {
            var client = new AsyncHttpClient(baseEndpoint,resultsPerPage,MakeJsonSettings());
            string  token= new ClientAuthorizationProvider(client, clientId, clientSecret).Token;
            if (token == null)
                throw new AuthenticationException();
            client.AddBearerAuthorization(token);
            return client;
        }

        internal static IAsyncHttpClient Create(string developerToken)
        {
            var client = new AsyncHttpClient(baseEndpoint, resultsPerPage, MakeJsonSettings());
            client.AddBearerAuthorization(developerToken);
            return client;
        }

        private static JsonSerializerSettings MakeJsonSettings()
        {
            var jsonSettings = new JsonSerializerSettings
            {
                    //MissingMemberHandling = MissingMemberHandling.Error,
                    //Error=(e, a) => { Console.WriteLine("Error: {0}", a.ErrorContext); }
            };
            //TODO: Generic + check all classes that implement IRootWithInstance/IRootWithInstances
            jsonSettings.Converters.Add(new RootWithTopicConverter());
            jsonSettings.Converters.Add(new RootWithTopicsConverter());
            jsonSettings.Converters.Add(new RootWithPostsConverter());
            jsonSettings.Converters.Add(new RootWithPostConverter());
            jsonSettings.Converters.Add(new RootWithCommentsConverter());
            return jsonSettings;
        }
    }
}
