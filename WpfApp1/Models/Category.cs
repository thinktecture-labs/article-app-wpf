using System.Runtime.Serialization;

namespace WpfApp1.Models
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Key { get; set; }
    }
}
