using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ProductHuntAPI.Models
{
    [DataContract]
    public class Token
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
        [DataMember(Name = "scope")]
        public string Scope { get; set; }
    }
}
