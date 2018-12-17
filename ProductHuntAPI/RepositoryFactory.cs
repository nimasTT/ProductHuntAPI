using ProductHuntAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI
{
    public class RepositoryFactory
    {
        private readonly IAsyncHttpClient vClient;
        public RepositoryFactory(string developerToken) : this(ClientFactory.Create(developerToken))
        { }

        public RepositoryFactory(string clientId, string clientSecret):this(ClientFactory.Create(clientId,clientSecret))
        {}

        private  RepositoryFactory(IAsyncHttpClient authorizedHttpClient)
        {
            if (authorizedHttpClient==null)
            throw new ArgumentNullException(nameof(authorizedHttpClient));
            if (!authorizedHttpClient.IsAuthorized)
                throw new ArgumentException(nameof(authorizedHttpClient) + $" is not authorized.");
            vClient = authorizedHttpClient;
        }

        public IRepository<Topic> CreateTopicRepository()
        {
            return new BaseRepository<Topic>(vClient, "/v1/topics");
        }

        public IRepository<Post> CreatePostRepository()
        {
            return new BaseRepository<Post>(vClient, "/v1/posts/all");
        }

        public IRepository<Comment> CreateCommentRepository()
        {
            return new CommentRepository(vClient, "/v1/comments");
        }
    }
}
