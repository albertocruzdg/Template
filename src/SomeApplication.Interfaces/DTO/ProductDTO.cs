using System;
using System.Runtime.Serialization;

namespace SomeApplication.Interfaces.DTO
{
    [DataContract]
    public class ProductDTO
    {
        [DataMember]
        public Guid? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public MoneyAmountDTO CurrentPrice { get; set; }
    }
}
