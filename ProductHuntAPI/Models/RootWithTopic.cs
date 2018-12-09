using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class RootWithTopic
    {
        [DataMember(Name ="topic")]
        public Topic Instance { get; set; }
    }
}
