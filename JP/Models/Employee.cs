using System.Security.Principal;

namespace JP.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Email { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public virtual Account? Account { get; set; }
    }
}