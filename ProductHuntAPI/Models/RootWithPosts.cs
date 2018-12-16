using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    internal class RootWithPosts:IRootWithInstances<Post>
    {
        [DataMember(Name = "posts")]
        public Post[] Instances { get; set; }
    }

    internal class RootWithPostsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IRootWithInstances<Post>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(RootWithPosts));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(RootWithPosts));
        }
    }
}
