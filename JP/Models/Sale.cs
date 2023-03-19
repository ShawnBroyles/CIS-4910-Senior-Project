namespace JP.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string SaleDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
    }
}
