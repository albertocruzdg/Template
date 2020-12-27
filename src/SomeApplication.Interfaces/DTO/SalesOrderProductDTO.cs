using System;
using System.Runtime.Serialization;

namespace SomeApplication.Interfaces.DTO
{
    [DataContract]
    public class SalesOrderProductDTO
    {
        [DataMember]
        public Guid ProductId { get; set; }

        [DataMember]
        public int Quantity { get; set; }
    }
}
