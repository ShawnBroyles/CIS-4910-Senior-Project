namespace JP.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int companyrevenue { get; set; }
        public virtual Catagory Catagory { get; set; }

    }
}
