namespace JP.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public virtual Employee Employee { get; set; } 
    }
}
