using System.Runtime.Serialization;

namespace WpfApp1.Models
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Manufacturer { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public string Subcategory { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int? PreviousId { get; set; }

        [DataMember]
        public int? NextId { get; set; }
    }
}
