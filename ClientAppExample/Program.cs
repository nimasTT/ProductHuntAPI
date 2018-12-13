using Newtonsoft.Json;
using ProductHuntAPI;
using ProductHuntAPI.Queries;
using System;
using System.IO;
using System.Linq;

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
            Console.WriteLine($"Client Authorized: {client.IsAuthorized.ToString()}");
            var repoFactory = new RepositoryFactory(client);
            
            //Topics
            var topicRepo = repoFactory.CreateTopicRepository();
            var topic = topicRepo.FindById(366);
            Console.WriteLine($"Topic {topic.Name}(Id {topic.Id}) has been fetched");
            Console.WriteLine(topic.Description);

            Console.WriteLine("Now search for topic 'cannabis' ");
            var query = new TopicQuery() { Slug = "cannabis" };
            var topics = topicRepo.Select(query);
            Console.WriteLine($"{topics.Length} topic has been loaded.");
            var cannabisTopic = topics.FirstOrDefault();
            Console.WriteLine($"Topic {cannabisTopic.Name}(Id {cannabisTopic.Id}) has been fetched");
            Console.WriteLine("Start fetching first 100 topics.");
            var baseQuery = new BaseQuery()
            {
                SelectType=SelectionType.Count,
                Count=100
            };
            topics = topicRepo.Select(baseQuery);
            Console.WriteLine($"{topics.Length} topics has been loaded");

            //Posts
            var postRepo = repoFactory.CreatePostRepository();
            var cannabisPosts = postRepo.Select(new PostQuery() { Topic = cannabisTopic.Id });
            Console.WriteLine($"{cannabisPosts.Length} posts related to {cannabisTopic.Name} topic has been loaded.");
            var mostCommentedPost=cannabisPosts.OrderByDescending(x => x.CommentsCount).First();
            Console.WriteLine($"The most commented one - {mostCommentedPost.Name } with {mostCommentedPost.CommentsCount} comments. Load them.");

            //Comments
            var commentsRepo = repoFactory.CreateCommentRepository();
            var comments = commentsRepo.Select(new CommentQuery() { PostId = mostCommentedPost.Id });
            Console.WriteLine($"{comments.Length} has been loaded. Here are they:");
            foreach (var comment in comments)
                Console.WriteLine(comment.Body);
            Console.WriteLine($"Load single comment Id={comments.First().Id}");
            Console.WriteLine($"Text : {commentsRepo.FindById(comments.First().Id).Body}");
            Console.ReadKey();
        }
    }
}
