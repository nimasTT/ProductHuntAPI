using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class RootWithTopics:IRootWithInstances<Topic>
    {
        [DataMember(Name = "topics")]
        public Topic[] Instances { get; set; }
    }

    public class RootWithTopicsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IRootWithInstances<Topic>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, typeof(RootWithTopics));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value, typeof(RootWithTopics));
        }
    }
}
