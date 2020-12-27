using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SomeApplication.Interfaces.DTO
{
    [DataContract]
    public class SalesOrderDTO
    {
        [DataMember]
        public string ClientIdentificationNumber { get; set; }

        [DataMember]
        public IEnumerable<SalesOrderProductDTO> Products { get; set; }
    }
}
