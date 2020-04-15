using System.Runtime.Serialization;

namespace WpfApp1.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public double Price { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
    }
}
