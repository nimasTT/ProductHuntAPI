using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProductHuntAPI.Models;

namespace ProductHuntAPI
{
    public class ClientConnectionManager : IConnectionManager
    {
        private string vToken;
        private readonly string vTokenEndpoint ="/v1/oauth/token";
        private readonly string vGrantType = "client_credentials";
        private readonly ApiHttpClient vHttpClient;
        private readonly TokenRequest vRequest;

        public ClientConnectionManager(string baseEndpoint, string Id, string secret)
        {
            vRequest = new TokenRequest
            {
                ClientId = Id,
                ClientSecret = secret,
                GrantType = vGrantType
            };
            vHttpClient=new ApiHttpClient( new Uri( baseEndpoint));
        }
        public string Token => vToken;

        public void Connect()
        {
            if (vToken != null) return;
            Uri tokenUri = vHttpClient.CreateRequestUri(vTokenEndpoint);
            var response = vHttpClient.PostAsync<TokenRequest, TokenResponse>( tokenUri, vRequest).Result;
            vToken = response.Token;
        }
    }
}
