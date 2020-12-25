using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SomeApplication.Business.DTO
{
    [DataContract]
    public class SalesOrderDTO
    {
        [DataMember]
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
