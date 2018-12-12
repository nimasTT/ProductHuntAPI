using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class User:IBaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "username")]
        public string UserName { get; set; }
        [DataMember(Name = "headline")]
        public string Headline { get; set; }
        [DataMember(Name = "twitter_username")]
        public string TwitterUserName { get; set; }
        [DataMember(Name = "website_url")]
        public Uri Website  { get; set; }
        [DataMember(Name = "profile_url")]
        public Uri Profile  { get; set; }
        [DataMember(Name = "image_url")]
        public Dictionary<string,Uri> Images { get; set; }
    }
}
