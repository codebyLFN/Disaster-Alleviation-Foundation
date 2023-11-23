using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class GoodsDonation
    {

        [Key]
        public int GoodsId { get; set; }
        public string DonorName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int ItemCount { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime DonationDate { get; set; } = DateTime.Now;
    }
}
