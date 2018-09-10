using System;

namespace POS.WebAPI.Entity
{
    public class ProcessEvent
    {
        public string company { get; set; }
        public string procName { get; set; }
        public string parameters { get; set; }
        public string result { get; set; }
        public string errorMsg { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }
        public string createdUser { get; set; }
    }
}
