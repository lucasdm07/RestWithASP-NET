using RestWithASPNET.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Tapioca.HATEOAS;

namespace RestWithASPNET.Data.VO
{ 
    [DataContract]
    public class PersonVO : ISupportsHyperMedia
    {
        [DataMember(Order = 1)]
        public long? Id { get; set; }
        [DataMember(Order = 2)]
        public string FirstName { get; set; }
        [DataMember(Order = 3)]
        public string LastName { get; set; }
        [DataMember(Order = 4)]
        public string Address { get; set; }
        [DataMember(Order = 5)]
        public string Gender { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
