using System;
using ProductHuntAPI.Models;

namespace ProductHuntAPI
{
    public class ClientAuthorizationProvider : IAuthorizationProvider
    {
        private string vToken;
        private readonly string vTokenEndpoint ="/v1/oauth/token";
        private readonly string vGrantType = "client_credentials";

        public ClientAuthorizationProvider(IAsyncHttpClient httpClient, string Id, string secret)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));
            if (secret == null)
                throw new ArgumentNullException(nameof(secret));

            var request = new TokenRequest
            {
                ClientId = Id,
                ClientSecret = secret,
                GrantType = vGrantType
            };
            Uri tokenUri = httpClient.CreateRequestUri(vTokenEndpoint);
            var response = httpClient.PostAsync<TokenRequest, Token>(tokenUri, request).Result;
            vToken = response.AccessToken;
        }
        
        public string Token => vToken;
    }
}
