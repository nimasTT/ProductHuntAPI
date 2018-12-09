using ProductHuntAPI;
using System;
using Newtonsoft.Json;
using System.IO;

namespace ClientAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText("config.json"));
            Console.WriteLine("Lets try ProductHunt API");
            Console.WriteLine("Establishing connection in CLient mode ... ");
            IAsyncHttpClient client = ClientFactory.Create(config.ClientId, config.ClientSecret);
            Console.WriteLine("Client Authorized: {0}", client.IsAuthorized.ToString()); 
            var topicRepo = new TopicRepository(client);
            var topic = topicRepo.FindById(366);
            Console.WriteLine($"Topic "+topic.Name+"("+topic.Id+") has been fetched");
            Console.WriteLine(topic.Description);
            Console.WriteLine("Now lets fetch all topis.");
            var allTopics = topicRepo.Select("");
            Console.WriteLine($"" + allTopics.Length + " topics has been loaded");
            Console.ReadKey();
        }
    }
}
