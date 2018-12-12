using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class Thumbnail:IBaseEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "media_type")]
        public string MediaType { get; set; }
        [DataMember(Name = "image_url")]
        public Uri Image { get; set; }
        //[DataMember(Name = "metadata")]
        //public Metadata metadata { get; set; }
    }
}
