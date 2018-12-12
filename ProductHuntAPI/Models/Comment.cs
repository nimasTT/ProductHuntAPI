using System;
using System.Runtime.Serialization;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class Comment:IBaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "body")]
        public string Body { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "parent_comment_id")]
        public int? ParentCommentId { get; set; }
        [DataMember(Name = "user_id")]
        public int UserId { get; set; }
        [DataMember(Name = "subject_id")]
        public int SubjectId { get; set; }
        [DataMember(Name = "child_comments_count")]
        public int ChildCommentsCount { get; set; }
        [DataMember(Name = "url")]
        public Uri Url { get; set; }
        [DataMember(Name = "post_id")]
        public int PostId { get; set; }
        [DataMember(Name = "subject_type")]
        public string SubjectType { get; set; }
        [DataMember(Name = "sticky")]
        public bool Sticky { get; set; }
        [DataMember(Name = "votes")]
        public int Votes { get; set; }
        [DataMember(Name = "post")]
        public Post Post { get; set; }
        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
