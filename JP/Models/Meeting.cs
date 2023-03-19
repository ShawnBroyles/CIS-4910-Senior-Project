namespace JP.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }
        public string meetingtime{ get; set; }
        public string meetingdate { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }  


    }
}
