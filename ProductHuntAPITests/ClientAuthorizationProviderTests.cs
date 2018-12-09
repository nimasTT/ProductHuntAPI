using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductHuntAPI;
using ProductHuntAPI.Models;
using Shouldly;
using System;

namespace ProductHuntAPITests
{
    [TestClass]
    public class ClientAuthorizationProviderTests
    {
        [TestMethod]
        public void ClientAuthorizationProviderShouldThrowExceptionWhenNullApiHttpClientPassed()
        {
            Should.Throw<ArgumentNullException>(() => new ClientAuthorizationProvider(null as AsyncHttpClient, "MyId", "secretstring"));
        }

        [TestMethod]
        public void ClientAuthorizationProviderShouldThrowExceptionWhenNullIdPassed()
        {
            var httpClientMoq = new Mock<IAsyncHttpClient>();
            Should.Throw<ArgumentNullException>(() => new ClientAuthorizationProvider(httpClientMoq.Object, null, "secretstring"));
        }

        [TestMethod]
        public void ClientAuthorizationProviderShouldThrowExceptionWhenNullSecretPassed()
        {
            var httpClientMoq = new Mock<IAsyncHttpClient>();
            Should.Throw<ArgumentNullException>(() => new ClientAuthorizationProvider(httpClientMoq.Object, "MyId", null));
        }

        [TestMethod]
        public void ClientAuthorizationProviderShouldRequestToken()
        {
            string tokenString = "someToken";
            var httpClientMoq = new Mock<IAsyncHttpClient>();
            httpClientMoq.Setup(x => x.PostAsync<TokenRequest, Token>(It.IsAny<Uri>(), It.IsAny<TokenRequest>()))
                .ReturnsAsync(() => new Token() { AccessToken=tokenString});
            var tokenProvider = new ClientAuthorizationProvider(httpClientMoq.Object, "MyId", "MySecret");
            tokenProvider.Token.ShouldBe(tokenString);
        }

    }
}
