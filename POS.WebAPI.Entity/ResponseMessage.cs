namespace POS.WebAPI.Entity
{
    public class ResponseMessage
    {
        public int Response { get; set; }
        public int TableId { get; set; }
        public string ResponseMsg { get; set; }
        public bool SendEmail { get; set; }
        public bool SendSMS { get; set; }
        public string ReceiverEmail { get; set; }
        public string ProcName { get; set; }
    }
}
