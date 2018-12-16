using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    internal class TokenRequest
    {
            [DataMember(Name = "client_id")]
            public string ClientId { get; set; }
            [DataMember(Name = "client_secret")]
            public string ClientSecret { get; set; }
            [DataMember(Name = "grant_type")]
            public string GrantType { get; set; }
    }
}
