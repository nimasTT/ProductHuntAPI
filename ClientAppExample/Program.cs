using ProductHuntAPI;
using System;
using Newtonsoft.Json;
using System.IO;
using ProductHuntAPI.Queries;
using ProductHuntAPI.Models;

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
            var repoFactory = new RepositoryFactory(client);
            var topicRepo = repoFactory.CreateTopicRepository();
            var topic = topicRepo.FindById(366);
            Console.WriteLine($"Topic " + topic.Name + "(" + topic.Id + ") has been fetched");
            Console.WriteLine(topic.Description);

            Console.WriteLine("Now search for topic 'medtech' ");
            var query = new TopicQuery() { Slug = "medtech" };
            var allTopics = topicRepo.Select(query);
            Console.WriteLine(allTopics.Length+$" topic has been loaded.");

            var baseQuery = new BaseQuery()
            {
                SelectType=SelectionType.Count,
                Count=100
            };
            allTopics = topicRepo.Select(baseQuery);
            Console.WriteLine($"" + allTopics.Length + " topics has been loaded");
            Console.ReadKey();
        }
    }
}
