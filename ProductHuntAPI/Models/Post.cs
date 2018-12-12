using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class Post:IBaseEntity
    {
        [DataMember(Name = "comments_count")]
        public int CommentsCount { get; set; }
        [DataMember(Name ="day")]
        public DateTime Day { get; set; }
        [DataMember(Name ="id")]
        public int Id { get; set; }
        [DataMember(Name ="name")]
        public string Name { get; set; }
        [DataMember(Name = "product_state")]
        public string ProductState { get; set; }
        [DataMember(Name = "tagline")]
        public string TagLine { get; set; }
        [DataMember(Name = "slug")]
        public string Slug { get; set; }
        [DataMember(Name = "ios_featured_at")]
        public object IosFeaturedAt { get; set; }
        [DataMember(Name = "votes_count")]
        public int VotesCount { get; set; }
        [DataMember(Name = "category_id")]
        public object CategoryId { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime  CreatedAt{ get; set; }
        [DataMember(Name = "current_user")]
        public User CurrentUser { get; set; }
        [DataMember(Name = "discussion_url")]
        public Uri DiscussionUrl { get; set; }
        [DataMember(Name = "exclusive")]
        public object Exclusive { get; set; }
        [DataMember(Name = "featured")]
        public bool Featured { get; set; }
        [DataMember(Name = "maker_inside")]
        public bool MakerInside { get; set; }
        [DataMember(Name = "makers")]
        public User[] Makers { get; set; }
        [DataMember(Name = "platforms")]
        public object[] Platforms { get; set; }
        [DataMember(Name = "redirect_url")]
        public Uri RedirectUri { get; set; }
        [DataMember(Name = "screenshot_url")]
        public Dictionary<string,Uri> Screenshots { get; set; }
        [DataMember(Name = "thumbnail")]
        public Thumbnail Thumbnail { get; set; }
        [DataMember(Name = "topics")]
        public Topic[] Topics { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
