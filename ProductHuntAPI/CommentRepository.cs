using ProductHuntAPI.Models;

namespace ProductHuntAPI
{
    public class CommentRepository:BaseRepository<Comment>, IRepository<Comment>
    {
        internal CommentRepository(IAsyncHttpClient authorizedHttpClient, string endpoint) : base(authorizedHttpClient, endpoint) { }
        public override Comment FindById(int id)
        {
            var comments = base.ExecuteQuery("per_page=1", id - 1);
            return comments.Length == 1 ? comments[0] : null;
        }
    }
}
