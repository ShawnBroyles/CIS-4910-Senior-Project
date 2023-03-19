using System.ComponentModel.DataAnnotations;

namespace JP.Models
{
    public class Account
    {
        [Key]
        public int accountID { get; set; }
        public string username { get; set; }
        public int password { get; set; }
    }
}
