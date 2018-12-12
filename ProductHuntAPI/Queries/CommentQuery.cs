using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Queries
{
    public class CommentQuery : BaseQuery,IQuery
    {
        public CommentQuery()
        {
            SelectType = SelectionType.All;
        }
        
        public int? UserId { get; set; }
        public int? PostId { get; set; }
        public int? AmaEventId { get; set; }

        public new string ToHttpQuery()
        {
            var httpQuery = base.ToHttpQuery();
            if (UserId != null)
                httpQuery += AddSearchPropertyToQuery("user_id", UserId.Value.ToString());
            if (PostId != null)
                httpQuery += AddSearchPropertyToQuery("post_id", PostId.Value.ToString());
            if (AmaEventId != null)
                httpQuery += AddSearchPropertyToQuery("ama_event_id", AmaEventId.Value.ToString());
            return httpQuery;
        }
    }
}
