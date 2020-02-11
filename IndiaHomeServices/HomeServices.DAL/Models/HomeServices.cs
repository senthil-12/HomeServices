using System;

namespace HomeServices.Data.Models
{
    public class Services
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int CategoryLkpId { get; set; }
        public string CategoryLkpName { get; set; }
        public string ServiceType { get; set; }
        public int Timing { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
