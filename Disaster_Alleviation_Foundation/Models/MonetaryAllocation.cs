using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Disaster_Alleviation_Foundation.Models
{
    public class MonetaryAllocation
    {
        [Key]
        public int AllocationId { get; set; }


        public int DisasterId { get; set; }


        public int MonetaryId { get; set; }


        public DateTime AllocationDate { get; set; }


        public int Amount { get; set; }

        // Define the relationships with other tables
        [ForeignKey("DisasterId")]
        public virtual Disaster? Disaster { get; set; }

        [ForeignKey("MonetaryId")]
        public virtual MonetaryDonation? MonetaryDonation { get; set; }
    }
}
