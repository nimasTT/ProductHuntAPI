using System;
using System.Collections.Generic;
using System.Text;

namespace ProductHuntAPI.Queries
{
    public class TopicQuery : BaseQuery,IQuery
    {
        public TopicQuery()
        {
            SelectType = SelectionType.All;
        }
        
        public bool? Trending { get; set; }
        public int? FollowerId { get; set; }
        public string Slug { get; set; }

        public new string ToHttpQuery()
        {
            var httpQuery = base.ToHttpQuery();
            if (Trending != null)
                httpQuery += AddSearchPropertyToQuery("trending", Trending.Value.ToString());
            if (FollowerId != null)
                httpQuery += AddSearchPropertyToQuery("follower_id", FollowerId.Value.ToString());
            if (Slug != null)
                httpQuery += AddSearchPropertyToQuery("slug", Slug);
            return httpQuery;
        }
    }
}
