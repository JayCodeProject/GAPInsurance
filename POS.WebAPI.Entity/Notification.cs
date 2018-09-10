using System;

namespace POS.WebAPI.Entity
{
    public class Notification
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Notification_Message { get; set; }
        public DateTime Time { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
    }
}
