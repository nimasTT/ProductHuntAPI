using ProductHuntAPI;
using System;


namespace ClientAppExample
{
    class Program
    {
        private static readonly string baseEndpoint = "https://api.producthunt.com";
        private static readonly string myId = "bb9b12c219041534113dfb29d1e42f491dddb45472b0f23e3551e93972be2358";
        private static readonly string mySecret = "fb79c6629d034bf478066e5adf5e9543dd2a69f6e63240ab57e61457c8977a35";
        static void Main(string[] args)
        {
            Console.WriteLine("Lets try ProductHunt API");
            Console.WriteLine("Establishing connection in CLient mode ... ");
            ClientConnectionManager connectionManager = new ClientConnectionManager(baseEndpoint,myId,mySecret);
            connectionManager.Connect();
            Console.WriteLine("Token - {0}", connectionManager.Token);
            Console.ReadKey();
        }
    }
}
