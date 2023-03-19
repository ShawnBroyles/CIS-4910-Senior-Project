namespace JP.Models
{
    public class Notes
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }    
        public string Contents { get; set; }
        public virtual Employee Employee { get; set; }  
        public virtual Catagory Catagory { get; set; } 
    }
}
