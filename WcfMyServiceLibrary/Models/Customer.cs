using System.Runtime.Serialization;

namespace WcfMyServiceLibrary.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember] 
        public int Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Phone { get; set; }
    }
}
