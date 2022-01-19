using System.Runtime.Serialization;

namespace WcfMyServiceLibrary.Models
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Product { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal Qty { get; set; }
        [DataMember]
        public byte[] OrderTime { get; set; }
    }
}
