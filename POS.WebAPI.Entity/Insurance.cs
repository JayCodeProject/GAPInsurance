using System;

namespace POS.WebAPI.Entity
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public float Price { get; set; }
        public DateTime ValidDate { get; set; }
        public string RiskLevel { get; set; }
        public string Coverage { get; set; }
        public int RiskLevelId { get; set; }
        public int CoverageId { get; set; }
        public float CovPeriod { get; set; }
        public string CreatedUser { get; set; }
    }
}
