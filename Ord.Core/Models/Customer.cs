using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ord.Core.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string CustomerCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string LastName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
