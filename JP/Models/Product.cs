using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }  
        public string ProductName { get; set; }
        public int ProdcuctPrice { get; set; }
        public DateTime createdate { get; set; }
        public string ProductDescription { get; set; }
        public virtual Catagory Catagory { get; set; }


    }
}
