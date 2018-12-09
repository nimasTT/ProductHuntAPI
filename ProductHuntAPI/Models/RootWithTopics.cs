using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class RootWithTopics
    {
        [DataMember(Name = "topics")]
        public Topic[] Instances { get; set; }
    }
}
