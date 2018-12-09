using ProductHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductHuntAPI
{
    public class TopicRepository : IRepository<Topic>
    {
        private readonly IAsyncHttpClient vHttpClient;
        private readonly string vEndpoint = "/v1/topics";
        
        public TopicRepository(IAsyncHttpClient authorizedHttpClient)
        {
            if (authorizedHttpClient == null)
                throw new ArgumentNullException(nameof(authorizedHttpClient));
            vHttpClient = authorizedHttpClient;
        }
        public Topic FindById(int id)
        {
            var uri = vHttpClient.CreateRequestUri(vEndpoint+"/"+id.ToString());
            return vHttpClient.GetAsync<RootWithTopic>(uri).Result.Instance;
        }
        public Topic[] Select(string query)
        {
            List<Topic> allTopics = new List<Topic>();
            
            //Fetch first round
            var topics = ExecuteQuery(query ,0);
            allTopics.AddRange(topics);
            int lastId;
            Uri uri;
            
            //Now fetch all others
            while (topics.Length == vHttpClient.ResultsPerPage)
            {
                lastId = topics.Select(x => x.Id).Max();
                topics = ExecuteQuery(query ,lastId);
                allTopics.AddRange(topics);
            }
            return allTopics.ToArray();
        }
        private Topic[] ExecuteQuery(string query,int? lastId)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            if (lastId != null)
                query = query + "&newer=" + lastId;
            var uri = vHttpClient.CreateRequestUri(vEndpoint,query);
            return vHttpClient.GetAsync<RootWithTopics>(uri).Result.Instances;
        }
    }
}
