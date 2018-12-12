using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class Topic:IBaseEntity
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "slug")]
        public string Slug { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "followers_count")]
        public int Followers { get; set; }
        [DataMember(Name = "posts_count")]
        public int Posts { get; set; }
        [DataMember(Name = "trending")]
        public bool Trending { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime Updated { get; set; }
        [DataMember(Name = "image")]
        public Uri Image { get; set; }
        
    }
}
