using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class ProductEntity
    {
        [Key]
        public int productID { get; set; }
        public string? productname { get; set; }
        public int? productprice { get; set; }
        public int? catID { get; set; }
        public DateTime Date { get; set; }
    }
}
