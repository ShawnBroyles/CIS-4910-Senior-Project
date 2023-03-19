namespace JP.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Email { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int phonenum { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Catagory Catagory { get; set; }
    }
}
