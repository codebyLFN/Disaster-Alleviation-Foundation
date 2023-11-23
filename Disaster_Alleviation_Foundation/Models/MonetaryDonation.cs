using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class MonetaryDonation
    {
        [Key]
        public int MonetaryId { get; set; }
        public string DonorName { get; set; }
        public int Amount { get; set; }
        public bool IsAnonymous { get; set; }
        public DateTime DonationDate { get; set; } = DateTime.Now;
    }
}
