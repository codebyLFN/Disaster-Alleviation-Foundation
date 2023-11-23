using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class Disaster
    {
        [Key]
        public int DisasterId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string RequiredAid { get; set; }
        public bool IsActive { get; set; }

        //List allocated goods and monetary
        public List<MonetaryAllocation>? MonetaryAllocations { get; set; }

        public List<GoodsAllocation>? GoodsAllocation { get; set; }
    }
}
